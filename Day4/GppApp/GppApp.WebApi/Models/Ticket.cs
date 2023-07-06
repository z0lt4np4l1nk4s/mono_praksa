using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.WebApi.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public Guid ZoneTypeId { get; set; }
        public ZoneType ZoneType { get; set; }
        public Guid TicketTypeId { get; set; }
        public TicketType TicketType { get; set; }
    }
}