using MusicFM.API.Features.Interfaces;

namespace MusicFM.API.Infrastructure.Persistence;

public class UnitOfWork: IUnitOfWork
{
    private readonly MusicFmDbContext _context;

    public UnitOfWork(MusicFmDbContext context)
    {
        _context = context;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }

    /// <summary>
    /// Save changes
    /// </summary>
    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    /// <summary>
    /// Save changes async
    /// </summary>
    /// <param name="cancellationToken"></param>
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}