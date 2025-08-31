namespace MusicFM.API.Features.GetTopTags;

public interface IGetTopTagsUseCase
{
    /// <summary>
    /// Method to get top tags
    /// </summary>
    public Task ExecuteAsync(CancellationToken cancellationToken);
}