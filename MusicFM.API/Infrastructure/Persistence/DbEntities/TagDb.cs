namespace MusicFM.API.Infrastructure.Persistence.DbEntities;

public class TagDb
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
}