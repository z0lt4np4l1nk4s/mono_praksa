using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.Model.Common
{
    public interface ISoldTicket
    {
        Guid Id { get; set; }
        Guid TicketId { get; set; }
        Guid EmployeeId { get; set; }
        Guid CustomerId { get; set; }
        Guid SellingPointId { get; set; }
        Guid PaymentTypeId { get; set; }
        DateTime CreationTime { get; set; }
    }
}