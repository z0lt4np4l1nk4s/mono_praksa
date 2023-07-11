using GppApp.Common;
using GppApp.Common.Filters;
using GppApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GppApp.Repository.Common
{
    public interface ITicketRepository
    {
        Task<PagedList<Ticket>> GetAll(Sorting sorting, Paging paging, TicketFilter ticketFilter);
    }
}
