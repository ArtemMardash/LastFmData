using Microsoft.EntityFrameworkCore;
using MusicFM.API.Core;
using MusicFM.API.Features.Interfaces;
using MusicFM.API.Infrastructure.Mapping;

namespace MusicFM.API.Infrastructure.Persistence.Repositories;

public class TagRepository: ITagRepository
{
    private readonly MusicFmDbContext _context;

    public TagRepository(MusicFmDbContext context)
    {
        _context = context;
    }
    
    public async Task CreateTagAsync(Tag tag, CancellationToken cancellationToken)
    {
        await _context.Tags.AddAsync(tag.ToDb(), cancellationToken);
    }

    public async Task<List<string>> GetAllTagsNameAsync(CancellationToken cancellationToken)
    {
        return await _context.Tags.Select(t => t.Name).ToListAsync(cancellationToken);
    }

    public async Task<Tag> GetTagByName(string name, CancellationToken cancellationToken)
    {
        var tagDb = await _context.Tags.FirstOrDefaultAsync(t => t.Name == name, cancellationToken);
        if (tagDb == null)
        {
            throw new InvalidOperationException("There is no tag with such a name");
        }

        return tagDb.ToDomain();
    }
}