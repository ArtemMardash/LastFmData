using MusicFM.API.Infrastructure.Services.WebClients;

namespace MusicFM.API.Features.GetAlbumsByArtists;

public class GetAlbumsByArtistsUseCase: IGetAlbumsByArtistsUseCase
{
    private readonly MusicFmClient _client;

    public GetAlbumsByArtistsUseCase(MusicFmClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Method to get all albums by all artists
    /// </summary>
    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await _client.GetAlbumsByArtistsAsync(cancellationToken);
    }
}