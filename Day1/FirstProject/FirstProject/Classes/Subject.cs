﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Classes
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int HourDuration { get; set; }

        public override string ToString()
        {
            return Name + $" ({HourDuration})";
        }
    }
}
