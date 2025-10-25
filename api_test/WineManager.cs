using System.Text.Json;
namespace api_test;

public static class WineManager
{
    public static List<Wine> Wines { get; set; }
    private static HttpClient _httpClient = new HttpClient();
    public static async Task<List<Wine>?> GetWines()
    {
        //Anropa API
        const string apiUrl = "https://api.sampleapis.com/wines/reds/";

        var response = await _httpClient.GetAsync(apiUrl);
        
        var json = await response.Content.ReadAsStringAsync();
        
        //Omvandla från JSON till C#
       var wines = JsonSerializer.Deserialize<List<Wine>>(json, JsonSerializerOptions.Default);
        //Spara den i våran wines-variabel
       if (wines != null)
       {
           Wines = wines;
       }

       foreach (var wine in wines)
       {
           Console.WriteLine(wine.Name);
       }

       return wines;
    }
}