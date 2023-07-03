using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        private int privateTest = 0;

        /// <summary>
        /// Method for getting the full name of the user
        /// </summary>
        /// <returns>The user's full name</returns>
        public string GetName()
        {
            return Name + " " + LastName;
        }

        /// <summary>
        /// Calculating the age of the user
        /// </summary>
        /// <returns>The users age</returns>
        public int GetAge()
        {
            return (int)(DateTime.Now.Subtract(DateOfBirth).TotalDays / 365);
        }

        /// <summary>
        /// Method for writing the user's info to the console
        /// </summary>
        public virtual void WriteInfo()
        {
            Console.WriteLine(GetName());
            Console.WriteLine("Age: " + GetAge());
        }
    }
}
