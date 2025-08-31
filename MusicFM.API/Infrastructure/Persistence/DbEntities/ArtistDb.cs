namespace MusicFM.API.Infrastructure.Persistence.DbEntities;

public class ArtistDb
{
    /// <summary>
    /// Id of artist
    /// </summary>
    public Guid Mbid { get; set; }

    /// <summary>
    /// Name of the artist
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Url of artist
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// List of tags
    /// </summary>
    public List<TagDb> Tags { get; set; }

    /// <summary>
    /// List of albums
    /// </summary>
    public virtual List<AlbumDb> Albums { get; set; }
}