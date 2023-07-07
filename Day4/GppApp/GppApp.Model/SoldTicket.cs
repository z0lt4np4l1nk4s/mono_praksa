using GppApp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GppApp.Model
{
    public class SoldTicket : ISoldTicket
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid SellingPointId { get; set; }
        public SellingPoint SellingPoint { get; set; }
        public Guid PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime CreationTime { get; set; }
    }
}