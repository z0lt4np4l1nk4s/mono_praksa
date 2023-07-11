using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.Model
{
    public class TicketTypeView
    {
        public string Name { get; set; }

        public TicketTypeView() { }

        public TicketTypeView(TicketType ticketType)
        {
            Name = ticketType.Name;
        }
    }
}