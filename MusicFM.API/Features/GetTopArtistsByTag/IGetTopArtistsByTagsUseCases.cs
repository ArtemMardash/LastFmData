namespace MusicFM.API.Features.GetTopArtistsByTag;

public interface IGetTopArtistsByTagsUseCases
{
    /// <summary>
    /// Method to get all artist by tags
    /// </summary>
    public Task ExecuteAsync(CancellationToken cancellationToken);
}