using MusicFM.API.Core;

namespace MusicFM.API.Features.Interfaces;

public interface IAlbumRepository
{
    public Task CreateAlbumAsync(Album album, CancellationToken cancellationToken);

    public Task<List<Album>> GetAlbumsByArtistId(Guid artistsMbid, CancellationToken cancellationToken);
}