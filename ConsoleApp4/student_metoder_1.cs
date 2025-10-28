/*
1. Filtrering – hitta duktiga studenter
Hämta alla studenter som har ett betyg över 80.
*/

using ConsoleApp4;

public class student_metoder_1 {
    private readonly List<Student> _students;
    private readonly int _upperThreshHold = 80;
    private readonly int _passableGrade = 50;
    private readonly int _highGrade = 70;
    public student_metoder_1(List<Student> students)
    {
        _students = students;
    }
    
public List<string> GetTopStudents()
{
    // TODO: Implementera med LINQ
    var studentsOverEigthy = _students.Where(s => s.Grade > _upperThreshHold)
        .OrderByDescending(s => s.Grade)
        .Select(s => $"{s.Name} has the grade of {s.Grade}")
        .ToList();
    return studentsOverEigthy;
}



/*
2. Sortering – ordna efter högsta betyg
Sortera studenterna i fallande ordning efter Grade och returnera namn + betyg.
Exempel: "Adam - 95"
*/
public List<string> GetStudentsSortedByGrade()
{
    var orderStudentsByGrade = _students.OrderByDescending(s => s.Grade)
        .Select(s => $"{s.Name} -  Grade: {s.Grade}")
        .ToList();
    return orderStudentsByGrade;
}


/*
3. Projektion – skapa en enklare lista
Returnera varje students namn + programnamn.
Exempel: "Adam - Undersköterska"
*/

public List<string> GetStudentProgramList()
{
    var studentByProgram = _students.Select(s => $"Student: {s.Name} - Program: {s.Program.Name}")
        .ToList();
    return studentByProgram;
}

/*
4. Gruppering – gruppera efter program
Returnera hur många som går varje program.
Exempel: "Undersköterska - 24 studenter"
*/
public List<(string Name, int Count)> GetStudentCountByProgram()
{
    var studentByProgram = _students.GroupBy(s => s.Program.Name)
        .Select(g => ( Name: g.Key, Count: g.Count() )).ToList();
    return studentByProgram;
}


/*
5. Aggerering – medelbetyg per program
Beräkna medelbetyg per program.
Exempel: "Undersköterska - snitt 72.5"
*/
public List<string> GetAverageGradeByProgram()
{
    var averageGradeByProgram = _students.GroupBy(s => s.Program.Name)
        .Select(g => $"{g.Key} has the average grade of: {g.Average(s => s.Grade):F1}").ToList();
    return averageGradeByProgram;
}


/*
6. Villkorskontroll – kontrollera betyg
Kontrollera om alla i "Undersköterska" har godkänt (>= 50).
Returnera true eller false.
*/
public bool AllNursesStudentsArePassing()
{
    var areNursesPassing = _students.Where(s => s.Program.Name == "Undersköterska")
        .All(s => s.Grade >= _passableGrade);
    return areNursesPassing;
}


/*
7. Åldersberäkning – äldsta studenten
Returnera den student som är äldst.
*/
public Student GetOldestStudent()
{
    var oldestStudent = _students.OrderBy(s => s.Birthday).First();
    return oldestStudent;
    // TODO: Implementera med LINQ
}


/*
8. Urval – top 5
Returnera de 5 studenter med högst betyg.
*/
public List<Student> GetTop5Students()
{
    var top5Students = _students.OrderByDescending(s => s.Grade)
        .Take(5)
        .ToList();
    return top5Students;
    // TODO: Implementera med LINQ
}


/*
9. Transformation – andel avklarade terminer
Returnera namn + procent avklarade terminer.
Exempel: "Adam - 70%"'
*/
public List<string> GetCompletionPercentage()
{
    var completionPercentage = _students
        .Select(s => $"{s.Name} has completed {s.Program.CurrentSemester / (double) s.Program.TotalSemester * 100}%")
        .ToList();
    return completionPercentage;
    // TODO: Implementera med LINQ
}


/*
10. Gruppfiltrering – program med snitt > 70
Returnera programnamn där medelbetyget överstiger 70.
Exempel: "Sjuksköterska"
*/
public List<string> GetProgramsWithHighAverage()
{
    var highAverageStudentInProgram = _students.GroupBy(s => s.Program.Name)
        .Where(g => g.Average(s => s.Grade) > _highGrade)
        .Select(g => g.Key)
        .ToList();
    if (highAverageStudentInProgram.Count == 0)
    {
        Console.WriteLine("There was no program with average of 70");
    }
    return highAverageStudentInProgram;
}
}