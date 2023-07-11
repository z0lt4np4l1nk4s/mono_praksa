using GppApp.Common;
using GppApp.Common.Filters;
using GppApp.Model;
using GppApp.Repository.Common;
using GppApp.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GppApp.Service
{
    public class TicketService : ITicketService
    {
        public ITicketRepository Repo { get; }
        public TicketService(ITicketRepository ticketRepository) => Repo = ticketRepository;

        public async Task<PagedList<Ticket>> GetAll(Sorting sorting, Paging paging, TicketFilter ticketFilter)
        {
            return await Repo.GetAll(sorting, paging, ticketFilter);
        }
    }
}
