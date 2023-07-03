using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Classes
{
    public class Professor : User
    {
        private readonly List<Subject> subjects = new List<Subject>();


        /// <summary>
        /// Method for writing the professor's info to the console
        /// </summary>
        public override void WriteInfo()
        {
            Console.WriteLine("Professor: " + GetName());
            if (subjects.Count == 0) Console.WriteLine("Not teaching anything");
            else Console.WriteLine("Teaching: " + string.Join(", ", subjects.Select(x => x.ToString())));
        }

        /// <summary>
        /// Method for accessing the professor's subjects
        /// </summary>
        /// <returns>List of the professor's subjects</returns>
        public List<Subject> GetSubjects() => subjects;

        /// <summary>
        /// Method for adding a subject to the professor. If the subject is already added to the professor, then nothing happens.
        /// </summary>
        /// <param name="subject">The subject object which will be added to the professor</param>
        public void AddSubject(Subject subject)
        {
            if (subjects.Any(x => x.Id == subject.Id)) return;
            subjects.Add(subject);
        }

        /// <summary>
        /// Method for removing a subject from the professor.
        /// </summary>
        /// <param name="subject">The subject object which will be removed from the professor</param>
        public void RemoveSubject(Subject subject)
        {
            Subject? oldSubject = subjects.SingleOrDefault(x => x.Id == subject.Id);
            if (oldSubject == null) return;
            subjects.Remove(oldSubject);
        }
    }
}
