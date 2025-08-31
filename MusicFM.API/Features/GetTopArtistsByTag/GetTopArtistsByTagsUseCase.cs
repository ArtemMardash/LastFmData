using MusicFM.API.Infrastructure.Services.WebClients;

namespace MusicFM.API.Features.GetTopArtistsByTag;

public class GetTopArtistsByTagsUseCase: IGetTopArtistsByTagsUseCases
{
    private readonly MusicFmClient _client;

    public GetTopArtistsByTagsUseCase(MusicFmClient client)
    {
        _client = client;
    }

    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await _client.GetTopArtistsByTagsAsync(cancellationToken);
    }
}