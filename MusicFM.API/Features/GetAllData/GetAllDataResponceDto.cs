namespace MusicFM.API.Features.GetAllData;

public class GetAllDataResponceDto
{
    /// <summary>
    /// List of artists 
    /// </summary>
    public List<ArtistResultDto> Result { get; set; }
}

public class ArtistResultDto
{
    /// <summary>
    /// Id Of artist
    /// </summary>
    public Guid Mbid { get; set; }
    
    /// <summary>
    /// Name of the artist
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Link to artist
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// List of tag names of the artist
    /// </summary>
    public List<string> TagsNames { get; set; }

    /// <summary>
    /// List of albums name of the artist
    /// </summary>
    public List<string> AlbumsNames { get; set; }
}