using GppApp.Model;
using GppApp.Service;
using GppApp.Service.Common;
using GppApp.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Helpers;
using System.Web.Http;

namespace GppApp.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        public readonly ICustomerService iCustomerService;
        public readonly ILocationService iLocationService;

        public CustomerController()
        {
            iCustomerService = new CustomerService();
            iLocationService = new LocationService();
        }

        // GET: api/Customer
        public HttpResponseMessage Get()
        {
            try
            {
                List<CustomerView> customers = iCustomerService.GetAll().Select(x => new CustomerView(x)).ToList();
                if (customers == null) throw new Exception();
                return Request.CreateResponse(HttpStatusCode.OK, customers);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }

        // GET: api/Customer/5
        public HttpResponseMessage Get(Guid id)
        {
            try
            {
                if (id == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
                Customer customer = iCustomerService.GetById(id);

                if (customer == null) return Request.CreateResponse(HttpStatusCode.NotFound);
                return Request.CreateResponse(HttpStatusCode.OK, new CustomerView(customer));
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }

        // POST: api/Customer
        public HttpResponseMessage Post([FromBody] CustomerView customer)
        {
            try
            {
                if (customer == null || customer.Location == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
                Customer newCustomer = new Customer()
                {
                    Id = Guid.NewGuid(),
                    DateOfBirth = customer.DateOfBirth,
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    RegisterDate = DateTime.UtcNow,
                    PhoneNumber = customer.PhoneNumber,
                    Location = new Location(customer.Location),
                };
                bool success = iCustomerService.Add(newCustomer);
                if(!success) return Request.CreateResponse(HttpStatusCode.BadRequest);
                return Request.CreateResponse(HttpStatusCode.OK, new CustomerView(newCustomer));
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }

        // PUT: api/Customer/5
        public HttpResponseMessage Put(Guid id, [FromBody] PutCustomer customer)
        {
            try
            {
                if (id == null || customer == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
                bool result = iCustomerService.Update(new Customer()
                {
                    Id = id,
                    PhoneNumber = customer.PhoneNumber,
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Location = new Location(customer.Location),
                });
                
                if (!result) return Request.CreateResponse(HttpStatusCode.BadRequest);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }

        // DELETE: api/Customer/5
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                if (id == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
                bool result = iCustomerService.Remove(id);
                if (!result) return Request.CreateResponse(HttpStatusCode.BadRequest, "Not deleted");
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }
    }
}
