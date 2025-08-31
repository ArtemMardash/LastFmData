namespace MusicFM.API.Core;

public class Artist
{
    public Guid Mbid { get; set; }
    
    public string Name { get; set; }
    
    public string Url { get; set; }

    public List<Tag> Tags { get; set; }

    public List<Album> Albums { get; set; }

    public Artist(Guid mbid, string name, string url, List<Tag> tags, List<Album> albums)
    {
        Mbid = mbid;
        Name = name;
        Url = url;
        Tags = tags;
        Albums = albums;
    }
}