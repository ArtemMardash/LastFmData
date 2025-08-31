using MusicFM.API.Core;
using MusicFM.API.Infrastructure.Persistence.DbEntities;

namespace MusicFM.API.Infrastructure.Mapping;

public static class DbToDomain
{
    public static Tag ToDomain(this TagDb tagDb)
    {
        return new Tag(tagDb.Id, tagDb.Name, tagDb.Reach, tagDb.Count);
    }

    public static Album ToDomain(this AlbumDb albumDb, Artist artist)
    {
        return new Album(albumDb.Name, albumDb.Mbid, artist, albumDb.Playcount);
    }

    public static Artist ToDomain(this ArtistDb artistDb)
    {
        var result = new Artist(
            artistDb.Mbid, 
            artistDb.Name, 
            artistDb.Url, 
            new List<Tag>(),
            new List<Album>()
        );
        result.Albums = artistDb.Albums.Count == 0? new List<Album>(): artistDb.Albums.Select(al => al.ToDomain(result)).ToList();
        result.Tags = artistDb.Tags.Select(t => t.ToDomain()).ToList();
        return result;
    }
}