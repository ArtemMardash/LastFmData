namespace MusicFM.API.Core;

public class Album
{
    public string Name { get; set; }
    public Guid Mbid { get; set; }

    public Artist Artist { get; set; }
    
    
    public long Playcount { get; set; }

    public Album(string name, Guid mbid, Artist artist, long playcount)
    {
        Name = name;
        Mbid = mbid;
        Artist = artist;
        Playcount = playcount;
    }
}