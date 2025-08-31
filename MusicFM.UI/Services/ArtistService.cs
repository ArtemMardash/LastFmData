namespace MusicFM.UI.Services;

public class ArtistService
{
    private readonly HttpClient _httpClient;

    public ArtistService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Method to get all data using Uri
    /// </summary>
    public async Task<DataDto?> GetArtistsAsync(CancellationToken cancellationToken)
    {
        return await _httpClient.GetFromJsonAsync<DataDto>("GetAllData", cancellationToken: cancellationToken);
    }
}