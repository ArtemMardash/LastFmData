namespace MusicFM.API.Infrastructure.Services.WebClients.Dtos;

public class TopArtistsDto
{
    public TopArtists topartists { get; set; }
}

public class TopArtists
{
    public List<ArtistDto> artist { get; set; }
}

public class ArtistDto
{
    public string mbid { get; set; }
    public string name { get; set; }
    public string url { get; set; }
}