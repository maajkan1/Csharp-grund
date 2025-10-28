using System.Globalization;
using System.Text.Json;

namespace ConsoleApp4;

class Program
{
    static void Main(string[] args)
    {
        string rawStudents = File.ReadAllText("students.json");

        var students = JsonSerializer.Deserialize<List<Student>>(rawStudents, JsonSerializerOptions.Web);

        /*var studentMetoder = new student_metoder_1(students ?? []);*/
        
        var studentMetoder2 = new student_metoder_2(students ?? []);
        
        studentMetoder2.GetGradeSpreadPerProgram().ForEach(Console.WriteLine);
    }
}