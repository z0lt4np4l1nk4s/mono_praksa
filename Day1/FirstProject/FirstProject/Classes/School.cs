using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstProject.Interfaces;

namespace FirstProject.Classes
{
    public class School : ISchool
    {
        public string Name { get; set; } = "";
        private readonly List<Student> students = new List<Student>();
        private readonly List<Professor> professors = new List<Professor>();

        public School(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Method for adding a professor to the school
        /// </summary>
        /// <param name="professor">The professor that should be added to the school</param>
        public void AddProfessor(Professor professor)
        {
            if (professors.Any(x => x.Id == professor.Id)) return;
            professors.Add(professor);
        }

        /// <summary>
        /// Method for adding a student to the school
        /// </summary>
        /// <param name="student">The student that should be added to the school</param>
        public void AddStudent(Student student)
        {
            if (students.Any(x => x.Id == student.Id)) return;
            students.Add(student);
        }

        /// <summary>
        /// Method for removing a student from the school
        /// </summary>
        /// <param name="student">The student that should be removed from the school</param>
        public void RemoveStudent(Student student)
        {
            Student? oldStudent = students.SingleOrDefault(x => x.Id == student.Id);
            if (oldStudent == null) return;
            students.Remove(oldStudent);
        }

        /// <summary>
        /// Method for removing a student from the school
        /// </summary>
        /// <param name="studentId">The student's Id that should be removed from the school</param>
        public void RemoveStudent(int studentId)
        {
            Student? oldStudent = students.SingleOrDefault(x => x.Id == studentId);
            if (oldStudent == null) return;
            students.Remove(oldStudent);
        }

        /// <summary>
        /// Method for removing a professor from the school
        /// </summary>
        /// <param name="professor">The professor that should be removed from the school</param>
        public void RemoveProfessor(Professor professor)
        {
            Professor? oldProfessor = professors.SingleOrDefault(x => x.Id == professor.Id);
            if (oldProfessor == null) return;
            professors.Remove(oldProfessor);
        }

        /// <summary>
        /// Method for removing a professor from the school
        /// </summary>
        /// <param name="professorId">The professor's Id that should be removed from the school</param>
        public void RemoveProfessor(int professorId)
        {
            Professor? oldProfessor = professors.SingleOrDefault(x => x.Id == professorId);
            if (oldProfessor == null) return;
            professors.Remove(oldProfessor);
        }

        /// <summary>
        /// Display the schools information on the console
        /// </summary>
        public void WriteSchoolInfo()
        {
            Console.WriteLine("School name: " + Name);
            Console.WriteLine(students.Count + " students");
            Console.WriteLine(professors.Count + " professors");
        }

        /// <summary>
        /// Displays the students information on the console
        /// </summary>
        public void WriteStudentsInfo()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No registered students in the school");
                return;
            }
            Console.WriteLine($"There are {students.Count} students in the school");
            Console.WriteLine("The students average grade is: " + students.Average(x => x.AverageGrade).ToString("0.00"));
        }

        /// <summary>
        /// Displays the information about all the students on the console
        /// </summary>
        public void WriteStudentsDetailedInfo()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No registered students in the school");
                return;
            }
            Console.WriteLine("\nDisplaying all students data:");
            foreach (Student student in students)
            {
                Console.WriteLine("--------------------");
                student.WriteInfo();
                Console.WriteLine("--------------------");
            }
        }

        /// <summary>
        /// Displays the professors information on the console
        /// </summary>
        public void WriteProfessorsInfo()
        {
            if (professors.Count == 0)
            {
                Console.WriteLine("No registered professors in the school");
                return;
            }
            Console.WriteLine($"There are {professors.Count} professors in the school");
            Console.WriteLine($"They teach a total of {professors.Sum(x => x.GetSubjects().Count)} subject");
        }

        /// <summary>
        /// Displays the information about all the professors on the console
        /// </summary>
        public void WriteProfessorsDetailedInfo()
        {
            if (professors.Count == 0)
            {
                Console.WriteLine("No registered professors in the school");
                return;
            }
            Console.WriteLine("\nDisplaying all professors data:");
            foreach (Professor professor in professors)
            {
                Console.WriteLine("--------------------");
                professor.WriteInfo();
                Console.WriteLine("--------------------");
            }
        }
    }
}
