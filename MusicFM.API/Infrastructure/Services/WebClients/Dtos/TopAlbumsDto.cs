namespace MusicFM.API.Infrastructure.Services.WebClients.Dtos;

public class TopAlbumsDto
{
    public TopAlbums Topalbums { get; set; }
}

public class TopAlbums
{
    public List<AlbumDto> Album { get; set; }
}

public class AlbumDto
{
    public string Mbid { get; set; }
    
    public string Name { get; set; }
    
    public string Url { get; set; }
    
    public long Playcount { get; set; }
    
    public ArtistDto Artist { get; set; }
}