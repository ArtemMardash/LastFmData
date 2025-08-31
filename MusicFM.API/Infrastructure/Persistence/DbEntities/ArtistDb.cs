namespace MusicFM.API.Infrastructure.Persistence.DbEntities;

public class ArtistDb
{
    public Guid Mbid { get; set; }

    public string Name { get; set; }

    public string Url { get; set; }

    public List<TagDb> Tags { get; set; }

    public virtual List<AlbumDb> Albums { get; set; }
}