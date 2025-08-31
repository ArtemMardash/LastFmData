namespace MusicFM.API.Features.GetAllData;

public interface IGetAllDataUseCase
{
    public Task<GetAllDataResponceDto> ExecuteAsync(CancellationToken cancellationToken);
}