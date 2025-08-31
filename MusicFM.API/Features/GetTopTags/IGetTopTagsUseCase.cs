namespace MusicFM.API.Features.GetTopTags;

public interface IGetTopTagsUseCase
{
    public Task ExecuteAsync(CancellationToken cancellationToken);
}