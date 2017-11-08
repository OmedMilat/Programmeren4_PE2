<Query Kind="Program" />

public List<Student> students;

void Main()
{
	
	students = new List<Student> {
							new Student { Id= 1, FirstName = "Freddie", LastName = "Fish", Age = 18 , Sex = "M"},
							new Student { Id= 2, FirstName = "Bill", LastName = "Jones", Age = 21, Sex = "M" },
							new Student { Id= 3, FirstName = "Kitty", LastName = "Cat", Age = 19, Sex = "F" },
							new Student { Id= 4, FirstName = "Suzy", LastName = "Wan", Age = 20, Sex = "F" }
					   };

	// 1. Studenten waarbij voor en familienaam start met dezelfde letter

students
.GroupBy(s => new{ s.FirstName, s.LastName})
.Select(s => new {Student = s.Key.FirstName +" "+ s.Key.LastName ,FirstInitial = s.Key.FirstName[0], LastInitial = s.Key.LastName[0]})
.Where(s=>s.FirstInitial == s.LastInitial)
.Dump("Oefening 1");

	// 2. Gemiddelde leeftijd van de vrouwelijke studenten
students
.Where(s => s.Sex == "F")
.GroupBy(s => s.Sex)
.Select(s => new { Geslacht = s.Key, Gemiddelde = s.Average(p => p.Age)})
.Dump("Oefening 2");

	// 3. Student met grootste code gevormd door id^2 + 5, toon ook de code

students
.Take(1)
.GroupBy(s => new{ s.FirstName, s.LastName})
.Select(s => new { Student = s.Key.FirstName +" "+ s.Key.LastName,
Code = s.Sum(p => p.Id^2+5)
})
.Dump("Oefening 3");


}




public class Student
{
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public int Age { get; set; }
	public string Sex { get; set; }
}