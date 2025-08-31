namespace MusicFM.API.Features.Interfaces;

public interface IUnitOfWork: IDisposable
{
    /// <summary>
    /// Save changes
    /// </summary>
    public void SaveChanges();

    /// <summary>
    /// Save changes async
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}