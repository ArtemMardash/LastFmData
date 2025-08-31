namespace MusicFM.API.Core;

public class Album
{
    /// <summary>
    /// Name of the album
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// ID of the album
    /// </summary>
    public Guid Mbid { get; set; }

    /// <summary>
    /// Artist that wrote thsi album
    /// </summary>
    public Artist Artist { get; set; }
    
    /// <summary>
    /// Plau count of this album
    /// </summary>
    public long Playcount { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public Album(string name, Guid mbid, Artist artist, long playcount)
    {
        Name = name;
        Mbid = mbid;
        Artist = artist;
        Playcount = playcount;
    }
}