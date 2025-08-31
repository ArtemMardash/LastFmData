using MusicFM.API.Core;

namespace MusicFM.API.Features.Interfaces;

public interface ITagRepository
{
    public Task CreateTagAsync(Tag tag, CancellationToken cancellationToken);

    public Task<List<string>> GetAllTagsNameAsync(CancellationToken cancellationToken);

    public Task<Tag> GetTagByName(string name, CancellationToken cancellationToken);
}