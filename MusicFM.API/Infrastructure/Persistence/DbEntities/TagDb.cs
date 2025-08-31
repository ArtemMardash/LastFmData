namespace MusicFM.API.Infrastructure.Persistence.DbEntities;

public class TagDb
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public int Reach { get; set; }
       
    public int Count { get; set; }
}