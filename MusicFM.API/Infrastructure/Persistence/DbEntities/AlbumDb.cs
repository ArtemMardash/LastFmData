namespace MusicFM.API.Infrastructure.Persistence.DbEntities;

public class AlbumDb
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
    public virtual ArtistDb Artist { get; set; }
    
    /// <summary>
    /// Plau count of this album
    /// </summary>
    public long Playcount { get; set; }
    
    /// <summary>
    /// Id of artist becuase artist itself is virtual
    /// </summary>
    public Guid ArtistsMbid { get; set; }
}