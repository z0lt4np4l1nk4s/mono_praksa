﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public class Student : User
    {
        public string ClassName { get; set; } = "";
        public double AverageGrade { get; set; }

        /// <summary>
        /// Method for writing the student's info to the console
        /// </summary>
        public override void WriteInfo()
        {
            Console.WriteLine("Student: " + GetName());
            Console.WriteLine("Average grade: " + AverageGrade.ToString("0.00"));
        }
    }
}
