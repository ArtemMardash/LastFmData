namespace MusicFM.API.Core;

public class Tag
{
    /// <summary>
    /// Id Of tag
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Name of the tag
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Reach of the tag
    /// </summary>
    public int Reach { get; set; }

    /// <summary>
    /// Count of how many times tag used
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Constructor For creating tag
    /// </summary>
    public Tag(string name, int reach, int count)
    {
        Id = new Guid();
        Name = name;
        Reach = reach;
        Count = count;
    }

    /// <summary>
    /// Constructor for mapping
    /// </summary>
    public Tag(Guid id, string name, int reach, int count)
    {
        Id = id;
        Name = name;
        Reach = reach;
        Count = count;
    }
}