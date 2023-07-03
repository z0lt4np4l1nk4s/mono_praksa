using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FirstProject
{
    public interface ISchool
    {
        /// <summary>
        /// Method for adding a professor to the school
        /// </summary>
        /// <param name="professor">The professor that should be added to the school</param>
        void AddProfessor(Professor professor);
        /// <summary>
        /// Method for adding a student to the school
        /// </summary>
        /// <param name="student">The student that should be added to the school</param>
        void AddStudent(Student student);
        /// <summary>
        /// Method for removing a student from the school
        /// </summary>
        /// <param name="student">The student that should be removed from the school</param>
        public void RemoveStudent(Student student);
        /// <summary>
        /// Method for removing a student from the school
        /// </summary>
        /// <param name="studentId">The student's Id that should be removed from the school</param>
        public void RemoveStudent(int studentId);
        /// <summary>
        /// Method for removing a professor from the school
        /// </summary>
        /// <param name="professor">The professor that should be removed from the school</param>
        void RemoveProfessor(Professor professor);
        /// <summary>
        /// Method for removing a professor from the school
        /// </summary>
        /// <param name="professorId">The professor's Id that should be removed from the school</param>
        void RemoveProfessor(int professorId);
        /// <summary>
        /// Display the schools information on the console
        /// </summary>
        void WriteSchoolInfo();
        /// <summary>
        /// Displays the students information on the console
        /// </summary>
        void WriteStudentsInfo();
        /// <summary>
        /// Displays the information about all the students on the console
        /// </summary>
        void WriteStudentsDetailedInfo();
        /// <summary>
        /// Displays the professors information on the console
        /// </summary>
        void WriteProfessorsInfo();
        /// <summary>
        /// Displays the information about all the professors on the console
        /// </summary>
        void WriteProfessorsDetailedInfo();
    }
}
