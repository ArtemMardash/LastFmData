namespace MusicFM.UI.Services;

public class ArtistService
{
    private readonly HttpClient _httpClient;

    public ArtistService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DataDto?> GetArtistsAsync(CancellationToken cancellationToken)
    {
        return await _httpClient.GetFromJsonAsync<DataDto>("GetAllData", cancellationToken: cancellationToken);
    }
}