using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GppApp.Model
{
    public class TicketView
    {
        public double Price { get; set; }
        public ZoneTypeView ZoneType { get; set; }
        public TicketTypeView TicketType { get; set; }

        public TicketView() { }

        public TicketView(Ticket ticket)
        {
            Price = ticket.Price;
            ZoneType = ticket.ZoneType == null ? null : new ZoneTypeView(ticket.ZoneType);
            TicketType = ticket.TicketType == null ? null : new TicketTypeView(ticket.TicketType);
        }
    }
}
