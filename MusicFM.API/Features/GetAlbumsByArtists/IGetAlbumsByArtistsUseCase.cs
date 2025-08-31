namespace MusicFM.API.Features.GetAlbumsByArtists;

public interface IGetAlbumsByArtistsUseCase
{
    public Task ExecuteAsync(CancellationToken cancellationToken);
}