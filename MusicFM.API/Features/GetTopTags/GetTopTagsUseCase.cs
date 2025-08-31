using MusicFM.API.Infrastructure.Services.WebClients;

namespace MusicFM.API.Features.GetTopTags;

public class GetTopTagsUseCase: IGetTopTagsUseCase
{
    private readonly MusicFmClient _client;

    public GetTopTagsUseCase(MusicFmClient client)
    {
        _client = client;
    }

    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await _client.GetTopTagsAsync(cancellationToken);
    }
}