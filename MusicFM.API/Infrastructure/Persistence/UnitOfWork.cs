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

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}