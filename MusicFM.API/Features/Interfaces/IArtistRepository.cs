using MusicFM.API.Core;

namespace MusicFM.API.Features.Interfaces;

public interface IArtistRepository
{
    public Task CreateArtistAsync(Artist artist, CancellationToken cancellationToken);
    
    public Task<bool> IsArtistExistsAsync(Guid mbid, CancellationToken cancellationToken);

    public Task UpdateArtistTags(Guid mbid, Tag tag, CancellationToken cancellationToken);

    public Task<List<Artist>> GetAllArtistsAsync(CancellationToken cancellationToken);

    public Task UpdateArtistsAlbumsAsync(Guid mbid, Album album, CancellationToken cancellationToken);
}