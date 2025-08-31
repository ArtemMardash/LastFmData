using MusicFM.API.Core;
using MusicFM.API.Infrastructure.Persistence.DbEntities;

namespace MusicFM.API.Infrastructure.Mapping;

public static class DomainToDb
{
    /// <summary>
    /// Tag to tag Db
    /// </summary>
    public static TagDb ToDb(this Tag tag)
    {
        return new TagDb
        {
            Id = tag.Id,
            Name = tag.Name,
            Reach = tag.Reach,
            Count = tag.Count,
        };
    }

    /// <summary>
    /// Album to AlbumDb
    /// </summary>
    /// <param name="album"></param>
    /// <returns></returns>
    public static AlbumDb ToDb(this Album album)
    {
        return new AlbumDb
        {
            Name = album.Name,
            Mbid = album.Mbid,
            Playcount = album.Playcount,
            ArtistsMbid = album.Artist.Mbid,
        };
    }

    /// <summary>
    /// Artist to ArtistDb. List of tgas maps in repositories
    /// </summary>
    public static ArtistDb ToDb(this Artist artist)
    {
        return new ArtistDb
        {
            Mbid = artist.Mbid,
            Name = artist.Name,
            Url = artist.Url,
            Albums = artist.Albums.Select(al => al.ToDb()).ToList(),
        };
    }
}