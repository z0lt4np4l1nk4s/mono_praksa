﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageProject.WebApi.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string Text { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}