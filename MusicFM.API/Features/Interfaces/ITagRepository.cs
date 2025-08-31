using MusicFM.API.Core;

namespace MusicFM.API.Features.Interfaces;

public interface ITagRepository
{
    /// <summary>
    /// Create tag for db
    /// </summary>
    public Task CreateTagAsync(Tag tag, CancellationToken cancellationToken);

    /// <summary>
    /// Get all tags name
    /// </summary>
    public Task<List<string>> GetAllTagsNameAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Get tag by name
    /// </summary>
    public Task<Tag> GetTagByName(string name, CancellationToken cancellationToken);
}