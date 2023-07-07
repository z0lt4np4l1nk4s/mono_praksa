using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.Model.Common
{
    public interface ITicket
    {
        Guid Id { get; set; }
        double Price { get; set; }
        Guid ZoneTypeId { get; set; }
        Guid TicketTypeId { get; set; }
    }
}