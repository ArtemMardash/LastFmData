namespace MusicFM.API.Features.GetAlbumsByArtists;

public interface IGetAlbumsByArtistsUseCase
{
    /// <summary>
    /// Method to get all albums by all artists
    /// </summary>
    public Task ExecuteAsync(CancellationToken cancellationToken);
}