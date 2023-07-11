using GppApp.Common;
using GppApp.Common.Filters;
using GppApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GppApp.Service.Common
{
    public interface ITicketService
    {
        Task<PagedList<Ticket>> GetAll(Sorting sorting, Paging paging, TicketFilter ticketFilter);
    }
}
