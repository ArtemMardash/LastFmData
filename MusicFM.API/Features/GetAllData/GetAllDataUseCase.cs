using MusicFM.API.Features.Interfaces;

namespace MusicFM.API.Features.GetAllData;

public class GetAllDataUseCase: IGetAllDataUseCase
{
    private readonly IArtistRepository _repository;

    public GetAllDataUseCase(IArtistRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Method to get all data
    /// </summary>
    public async Task<GetAllDataResponceDto> ExecuteAsync(CancellationToken cancellationToken)
    {
        var list = await _repository.GetAllArtistsAsync(cancellationToken);

        return new GetAllDataResponceDto
        {
            Result = list.Select(a => new ArtistResultDto
            {
                Mbid = a.Mbid,
                Name = a.Name,
                Url = a.Url,
                TagsNames = a.Tags.Select(t => t.Name).ToList(),
                AlbumsNames = a.Albums.Select(al => al.Name).ToList()
            }).ToList()
        };
    }
}