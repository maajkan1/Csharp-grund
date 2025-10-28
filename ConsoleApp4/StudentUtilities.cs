namespace ConsoleApp4;

public class StudentUtilities
{
    private readonly List<Student> _students;

    public StudentUtilities(List<Student> students)
    {
        _students = students;
    }
    
    // Skapa metoder för att plocka ut studenter enligt olika krav eller behov
    
    // Hämta alla godkända elever

    // Gamla sättet att jobba i C#, innan LINQ introducerades
    public List<Student> GetPassedStudents()
    {
        var passedStudents = new List<Student>();

        foreach (var student in _students)
        {
            if (student.Grade >= 50)
            {
                passedStudents.Add(student);
            }
        }
        
        return passedStudents;
    }

    public List<Student> GetPassedStudents2() => _students.Where(student => student.Grade >= 50).ToList();
        
    // Hämta topp 5 studenter, och ge mig deras namn och betyg. Exempel: Ahmad 100
    
    
    /*
     *  LINQ har två syntaxer:
     *  Metod-syntaxen
     *  Query-syntaxen
     */

    public List<string> GetTopStudentsName()
    {

        // Nedanstående är endast en instruktion, men den har inte exekverats.
        
        // Metod-syntax
        var topStudentsQuery = _students
            .Where(s => s.Grade >= 50)
            .OrderByDescending(s => s.Grade)
            .Select(s => $"{s.Name} {s.Grade}")
            .Take(5);

        // Query-syntax
        var topStudentsQuery2 = (from student in _students
            where student.Grade >= 50
            orderby student.Grade descending
            select $"{student.Name} {student.Grade}")
            .Take(5);
        
        // En LINQ query kommer att exekvera antingen om man materialiserar den eller kör en forEach på queryn.

        // Itererar över den – Kommer att exekvera LINQen
        foreach (var student in topStudentsQuery)
        {
            
        }
        
        // Materialiserar den i form av en array/list – Kommer att exekvera LINQen
        var topStudentsArray = topStudentsQuery.ToArray(); // string[]
        var topStudentsList = topStudentsQuery.ToList(); // List<string>
            

        
        return topStudentsList;
    }


}
