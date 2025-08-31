namespace MusicFM.API.Core;

public class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public int Reach { get; set; }

    public int Count { get; set; }


    public Tag(string name, int reach, int count)
    {
        Id = new Guid();
        Name = name;
        Reach = reach;
        Count = count;
    }

    public Tag(Guid id, string name, int reach, int count)
    {
        Id = id;
        Name = name;
        Reach = reach;
        Count = count;
    }
}