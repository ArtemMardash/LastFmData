namespace MusicFM.UI.Services;

public class DataDto
{
    public List<ArtistResultDto> Result { get; set; }
}

public class ArtistResultDto
{
    public Guid Mbid { get; set; }
    
    public string Name { get; set; }
    
    public string Url { get; set; }

    public List<string> TagsNames { get; set; }

    public List<string> AlbumsNames { get; set; }
}