namespace MusicFM.API.Infrastructure.Services.WebClients.Dtos;

public class TopTagDto
{
    public TopTagsDto toptags { get; set; }  
}

public class TopTagsDto
{
    public List<TagDto> tag { get; set; }
}

public class TagDto
{
    public string name { get; set; }
    
    public int count { get; set; }
    
    public int reach { get; set; }
    
    public string url { get; set; }
}