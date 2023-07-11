using GppApp.Common.Filters;
using GppApp.Common;
using GppApp.Model;
using GppApp.Service.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.Web.Http;
using System.Threading.Tasks;

namespace GppApp.WebApi.Controllers
{
    public class TicketController : ApiController
    {
        public ITicketService TicketService { get; }

        public TicketController(ITicketService ticketService)
        {
            TicketService = ticketService;
        }

        // GET: api/Ticket
        public async Task<HttpResponseMessage> Get(double? minPrice = null, double? maxPrice = null, string zoneTypes = null, string ticketTypes = null, string sortBy = "Price", string sortOrder = "ASC", int pageNumber = 1, int pageSize = 3)
        {
            try
            {
                Sorting sorting = new Sorting
                {
                    SortBy = sortBy,
                    SortOrder = sortOrder
                };
                if (sorting.SortOrder.ToLower() != "desc" && sorting.SortOrder.ToLower() != "asc") sorting.SortOrder = "ASC";
                Paging paging = new Paging()
                {
                    CurrentPage = pageNumber,
                    PageSize = pageSize
                };
                TicketFilter ticketFilter = new TicketFilter()
                {
                    MinPrice = minPrice,
                    MaxPrice = maxPrice,
                };

                if (ticketTypes != null)
                {
                    ticketFilter.TicketTypes = ticketTypes.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => Guid.Parse(x)).ToList();
                }

                if (zoneTypes != null)
                {
                    ticketFilter.ZoneTypes = zoneTypes.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => Guid.Parse(x)).ToList();
                }

                PagedList<Ticket> tickets = await TicketService.GetAll(sorting, paging, ticketFilter);

                PagedList<TicketView> pagedList = new PagedList<TicketView>
                {
                    CurrentPage = tickets.CurrentPage,
                    ItemCount = tickets.ItemCount,
                    LastPage = tickets.LastPage,
                    PageSize = tickets.PageSize,
                    Data = tickets.Data.Select(x => new TicketView(x)).ToList()
                };

                return Request.CreateResponse(HttpStatusCode.OK, pagedList);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }

        // GET: api/Ticket/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Ticket
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Ticket/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Ticket/5
        public void Delete(int id)
        {
        }
    }
}
