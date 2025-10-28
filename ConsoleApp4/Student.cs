using System.Text.Json.Serialization;

namespace ConsoleApp4;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    [JsonPropertyName("birthdate")]
    public DateTime Birthday { get; set; }
    public int Grade { get; set; } // Skala 0–100, under 50 är underkänt.
    public ProgramInfo Program { get; set; }
}
