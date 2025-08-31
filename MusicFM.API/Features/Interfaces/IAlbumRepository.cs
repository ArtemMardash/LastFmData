using MusicFM.API.Core;

namespace MusicFM.API.Features.Interfaces;

public interface IAlbumRepository
{
    /// <summary>
    /// Create entity albumDb for db
    /// </summary>
    public Task CreateAlbumAsync(Album album, CancellationToken cancellationToken);

    /// <summary>
    /// Get albums by aristId
    /// </summary>
    public Task<List<Album>> GetAlbumsByArtistId(Guid artistsMbid, CancellationToken cancellationToken);
}