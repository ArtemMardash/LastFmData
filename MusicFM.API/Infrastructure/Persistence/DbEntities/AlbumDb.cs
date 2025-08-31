namespace MusicFM.API.Infrastructure.Persistence.DbEntities;

public class AlbumDb
{
    public Guid Mbid { get; set; }

    public string Name { get; set; }

    public Guid ArtistsMbid { get; set; }

    public virtual ArtistDb Artist { get; set; }
    
    public long Playcount { get; set; }
}