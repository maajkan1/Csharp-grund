using ConsoleApp4;

public class student_metoder_2
{

    private readonly List<Student> _students;

    public student_metoder_2(List<Student> students)
    {
        _students = students;
    }

/*
1. Toppstudent per program
Gruppera studenter per program och returnera den med högst betyg.
Exempel: "Undersköterska: Mosa - 95"
*/

public List<string> GetTopStudentPerProgram()
{
    var topStudentPerProgram = _students
        .GroupBy(s => s.Program.Name)
        .Select(g =>
        {
            var topStudent = g.OrderByDescending(s => s.Grade).First();
            return $"{g.Key} - {topStudent.Name} {topStudent.Grade}";
        }).ToList();
    return topStudentPerProgram;

}


/*
2. Rangordning inom program
Sortera studenterna inom varje program efter betyg och visa en rank.
Exempel: "Undersköterska: 1. Mosa (95), 2. Ali (83)"
*/
public List<string> GetRankedStudentsByProgram()
{
    var bestStudentOfClassByIndex = _students.GroupBy(c => c.Program.Name)
        .SelectMany(g =>
            g.OrderByDescending(s => s.Grade)
                .Select((s, index) => $"{g.Key}: {index + 1}. {s.Name} ({s.Grade})"))
        .ToList();
    return bestStudentOfClassByIndex;
}


/*
3. Betygsspridning per program
Beräkna skillnaden mellan högsta och lägsta betyg i varje program.
Exempel: "Undersköterska - spridning: 28"
*/
    public List<string> GetGradeSpreadPerProgram()
    {
        var gradeScoreDifferenceByProgram = _students
            .GroupBy(s => s.Program.Name)
            .Select(s =>
            {
                var topStudent = s.OrderByDescending(t => t.Grade).First();
                var bottomStudent = s.OrderBy(b => b.Grade).First();
                return $"{s.Key} - spridning: {topStudent.Grade - bottomStudent.Grade}";

            }).ToList();
        return gradeScoreDifferenceByProgram;

    }

    //GroupBy
    //Select.First och last och gör minus?
    //Skriv ut det

/*
4. Medelbetyg per kön och program
Returnera snittbetyg uppdelat på kön *och* program.
Exempel: "Female - Undersköterska: 74.3"
#1#
public List<string> GetAverageByGenderAndProgram()
{
    // TODO
}


/*
5. Åldersgrupper – medelbetyg
Dela in i grupper: <25, 25-30, >30
Returnera medelbetyg i varje grupp.
Exempel: "<25: snitt 68"
*/
    /*public List<string> GetAgeGroupAverages()
    {
        
    }*/


/*
6. Program rankade efter medelbetyg
Sortera program efter snittbetyg (högst först).
Exempel: "1. Sjuksköterska (snitt 82)"
#1#
public List<string> GetProgramsRankedByAverage()
{
    // TODO
}


/*
7. Topp 3 per program
Returnera de tre med högst betyg inom varje program.
Exempel:
"Undersköterska: Mosa (95), Ali (83), Sara (80)"
#1#
public List<string> GetTopThreeStudentsPerProgram()
{
    // TODO
}
*/
}