﻿using FirstProject.Classes;
using FirstProject.Interfaces;

ISchool iSchool = new School("MATHOS");

//Creating student objects
Student pero = new Student()
{
    Id = 1,
    Name = "Pero",
    LastName = "Perić",
    DateOfBirth = new DateTime(2000, 9, 5),
    AverageGrade = 4.5,
    ClassName = "MiR"
};

Student lucija = new Student()
{
    Id = 2,
    Name = "Lucija",
    LastName = "Lucic",
    DateOfBirth = new DateTime(2001, 4, 27),
    AverageGrade = 4.1,
    ClassName = "MiR"
};

Student ivan = new Student()
{
    Id = 3,
    Name = "Ivan",
    LastName = "Ivic",
    DateOfBirth = new DateTime(2001, 1, 12),
    AverageGrade = 4.0,
    ClassName = "MiR"
};

Student lovro = new Student()
{
    Id = 4,
    Name = "Lovro",
    LastName = "Lovric",
    DateOfBirth = new DateTime(2000, 5, 24),
    AverageGrade = 4.9,
    ClassName = "MiR"
};

Student consoleStudent = new Student() { Id = 5 };
Console.WriteLine("Unesite ime studenta: ");
consoleStudent.Name = Console.ReadLine() ?? "";
Console.WriteLine("Unesite prezime studenta: ");
consoleStudent.LastName = Console.ReadLine() ?? "";
Console.WriteLine("Unesite razred studenta: ");
consoleStudent.ClassName = Console.ReadLine() ?? "";
Console.WriteLine("Unesite prosjek studenta: ");
consoleStudent.AverageGrade = Convert.ToDouble(Console.ReadLine() ?? "0");
Console.WriteLine("Unesite datum rodenja studenta u formatu (yyyy.MM.dd): ");
string[] array = (Console.ReadLine() ?? "").Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
consoleStudent.DateOfBirth = new DateTime(Convert.ToInt32(array[0]), Convert.ToInt32(array[1]), Convert.ToInt32(array[2]));

//Displaying a few students info
Console.WriteLine();
consoleStudent.WriteInfo();
Console.WriteLine();
lucija.WriteInfo();
Console.WriteLine();
lovro.WriteInfo();

//Adding the students to the school
List<Student> students = new List<Student> { pero, lucija, ivan, lovro, consoleStudent};

foreach (Student student in students) iSchool.AddStudent(student);

//Creating the professor objects
Professor luka = new Professor()
{
    Id = 1,
    Name = "Luka",
    LastName = "Bor",
    DateOfBirth = new DateTime(1990, 5, 9),
};

Professor domagoj = new Professor()
{
    Id = 2,
    Name = "Domagoj",
    LastName = "Mat",
    DateOfBirth = new DateTime(1978, 7, 12),
};

Professor dragana = new Professor()
{
    Id = 3,
    Name = "Dragana",
    LastName = "Jank",
    DateOfBirth = new DateTime(1989, 2, 1),
};

Professor tomislav = new Professor()
{
    Id = 4,
    Name = "Tomislav",
    LastName = "Prus",
    DateOfBirth = new DateTime(1999, 8, 19),
};

Professor klara = new Professor()
{
    Id = 5,
    Name = "Klara",
    LastName = "Fin",
    DateOfBirth = new DateTime(1998, 10, 10),
};

//Displaying a few professors info
Console.WriteLine();
dragana.WriteInfo();
Console.WriteLine();
tomislav.WriteInfo();

//Adding the professors to the school
List<Professor> professors = new List<Professor> { luka, domagoj, dragana, tomislav, klara };

foreach (Professor professor in professors) iSchool.AddProfessor(professor);

//Adding subjects to the professors
domagoj.AddSubject(new Subject { Id = 1, HourDuration = 105, Name = "Object oriented programing" });
domagoj.AddSubject(new Subject { Id = 2, HourDuration = 105, Name = "Algorithms and data structures" });
tomislav.AddSubject(new Subject { Id = 3, HourDuration = 90, Name = "Functional programming" });
luka.AddSubject(new Subject { Id = 4, HourDuration = 90, Name = "Mathematical logic in computer science" });
luka.AddSubject(new Subject { Id = 5, HourDuration = 90, Name = "Modern computer systems" });
dragana.AddSubject(new Subject { Id = 6, HourDuration = 140, Name = "Linear algebra" });

//Displaying a few professors updated info
Console.WriteLine();
dragana.WriteInfo();
Console.WriteLine();
tomislav.WriteInfo();

//Displaying the school's info
Console.WriteLine();
iSchool.WriteSchoolInfo();
iSchool.WriteStudentsInfo();
iSchool.WriteProfessorsInfo();

//Displaying the professors detailed info
iSchool.WriteProfessorsDetailedInfo();
//Removing a professor from the school
iSchool.RemoveProfessor(klara);
//Displaying the professors updated info
iSchool.WriteProfessorsDetailedInfo();

//Displaying the students detailed info
iSchool.WriteStudentsDetailedInfo();
//Removing a student from the school
iSchool.RemoveStudent(ivan);
//Displaying the students updated info
iSchool.WriteStudentsDetailedInfo();

Console.WriteLine();
//Testing how primitive and complex datatypes work
Student testStudent = ivan;
testStudent.ClassName = "M";
//ClassName for Ivan changed as well
ivan.WriteInfo();
//Complex data types use shallow copy

Console.WriteLine();
string className = ivan.ClassName;
className = "MiR";
//The class name for Ivan didn't change
Console.WriteLine(className + " - " + ivan.ClassName);
//Primitive data types use deep copy

//Its not possible to create an object from an abstract class
//User user = new User();