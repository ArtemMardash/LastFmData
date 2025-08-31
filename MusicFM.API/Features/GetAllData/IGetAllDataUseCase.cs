namespace MusicFM.API.Features.GetAllData;

public interface IGetAllDataUseCase
{
    /// <summary>
    /// Method to get all data
    /// </summary>
    public Task<GetAllDataResponceDto> ExecuteAsync(CancellationToken cancellationToken);
}