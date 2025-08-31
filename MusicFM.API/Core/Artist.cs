namespace MusicFM.API.Core;

public class Artist
{
    /// <summary>
    /// Id of Artist
    /// </summary>
    public Guid Mbid { get; set; }
    
    /// <summary>
    /// Name of the artist
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Link to the artist
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// List of tags/genres
    /// </summary>
    public List<Tag> Tags { get; set; }

    /// <summary>
    /// List of albums
    /// </summary>
    public List<Album> Albums { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public Artist(Guid mbid, string name, string url, List<Tag> tags, List<Album> albums)
    {
        Mbid = mbid;
        Name = name;
        Url = url;
        Tags = tags;
        Albums = albums;
    }
}