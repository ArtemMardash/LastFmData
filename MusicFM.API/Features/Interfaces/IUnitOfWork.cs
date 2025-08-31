namespace MusicFM.API.Features.Interfaces;

public interface IUnitOfWork: IDisposable
{
    public void SaveChanges();

    public Task SaveChangesAsync(CancellationToken cancellationToken);
}