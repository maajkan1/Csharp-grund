using System.Text.Json.Serialization;

namespace api_test;

public class Wine
{
    public int Id { get; set; }
    public string Winery { get; set; }
    [JsonPropertyName("wine")] 
    public string Name { get; set; }
    public Rating Rating { get; set; }
    public string Location { get; set; }
    public string Image { get; set; }
    
}

public class Rating
{
    public string Average { get; }
    public string Reviews { get; }
}