using Microsoft.Extensions.Options;
using MusicFM.API.Core;
using MusicFM.API.Features.Interfaces;
using MusicFM.API.Infrastructure.Services.WebClients.Dtos;

namespace MusicFM.API.Infrastructure.Services.WebClients;

public class MusicFmClient
{
    private readonly HttpClient _httpClient;
    private readonly ITagRepository _tagRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IArtistRepository _artistRepository;
    private readonly IAlbumRepository _albumRepository;
    private readonly MusicFmSettings _settings;

    public MusicFmClient(HttpClient httpClient, IOptions<MusicFmSettings> settings, ITagRepository tagRepository,
        IUnitOfWork unitOfWork, IArtistRepository artistRepository, IAlbumRepository albumRepository)
    {
        _httpClient = httpClient;
        _tagRepository = tagRepository;
        _unitOfWork = unitOfWork;
        _artistRepository = artistRepository;
        _albumRepository = albumRepository;
        _settings = settings.Value;
    }

    public async Task GetTopTagsAsync(CancellationToken cancellationToken)
    {
        var uri = $"2.0/?method=tag.getTopTags&api_key={_settings.ApiKey}&format=json";
        var response = await _httpClient.GetAsync(uri, cancellationToken);
        var result = await response.Content.ReadFromJsonAsync<TopTagDto>(cancellationToken);
        foreach (var tag in result.toptags.tag)
        {
            var tagToAdd = new Tag(tag.name, tag.reach, tag.count);
            await _tagRepository.CreateTagAsync(tagToAdd, cancellationToken);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task GetTopArtistsByTagsAsync(CancellationToken cancellationToken)
    {
        var tagNames = await _tagRepository.GetAllTagsNameAsync(cancellationToken);
        
        foreach (var tagName in tagNames)
        {
            var uri = $"2.0/?method=tag.gettopartists&tag={tagName}&api_key={_settings.ApiKey}&format=json";
            var responce = await _httpClient.GetAsync(uri, cancellationToken);
            var result = await responce.Content.ReadFromJsonAsync<TopArtistsDto>(cancellationToken);
            foreach (var art in result.topartists.artist)
            {
                Guid mbid;
                if (!string.IsNullOrWhiteSpace(art.mbid) && Guid.TryParse(art.mbid, out mbid))
                {
                    var tag = await _tagRepository.GetTagByName(tagName, cancellationToken);
                    if (await _artistRepository.IsArtistExistsAsync(mbid, cancellationToken))
                    {
                        await _artistRepository.UpdateArtistTags(mbid, tag, cancellationToken);
                    }
                    else
                    {
                        var artist = new Artist(Guid.Parse(art.mbid), art.name, art.url, new List<Tag> { tag },
                            new List<Album>());
                        await _artistRepository.CreateArtistAsync(artist, cancellationToken);
                    }

                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                }
                else //skip artist if he doesn't have mbid
                {
                    continue;
                }
            }
        }
    }

    public async Task GetAlbumsByArtistsAsync(CancellationToken cancellationToken)
    {
        var artists = await _artistRepository.GetAllArtistsAsync(cancellationToken);
        foreach (var artist in artists)
        {
            var uri = $"/2.0/?method=artist.gettopalbums&artist={artist.Name}&api_key={_settings.ApiKey}&format=json";
            var response = await _httpClient.GetAsync(uri, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Failed to fetch albums for {artist.Name}. Status: {response.StatusCode}");
                continue;
            }

            TopAlbumsDto? result = null;
            try
            {
                result = await response.Content.ReadFromJsonAsync<TopAlbumsDto>(cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to deserialize albums for {artist.Name}: {ex.Message}");
                continue;
            }
            if (result?.Topalbums?.Album == null || !result.Topalbums.Album.Any())
            {
                Console.WriteLine($"No albums found for {artist.Name}");
                continue;
            }

            foreach (var albumDto in result.Topalbums.Album)
            {
                if (Guid.TryParse(albumDto.Mbid, out var mbid)
                    && albumDto.Playcount > 0
                    && !string.IsNullOrWhiteSpace(albumDto.Name)
                    && !string.IsNullOrWhiteSpace(albumDto.Url))
                {
                        var album = new Album(albumDto.Name, mbid, artist, albumDto.Playcount);
                        await _albumRepository.CreateAlbumAsync(album, cancellationToken);
                        await _unitOfWork.SaveChangesAsync(cancellationToken);
                        await _artistRepository.UpdateArtistsAlbumsAsync(artist.Mbid, album, cancellationToken);
                        await _unitOfWork.SaveChangesAsync(cancellationToken);

                }
            }
        }
    }
}