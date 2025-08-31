namespace MusicFM.API.Features.GetTopArtistsByTag;

public interface IGetTopArtistsByTagsUseCases
{
    public Task ExecuteAsync(CancellationToken cancellationToken);
}