﻿using GppApp.Model;
using GppApp.Service;
using GppApp.Service.Common;
using GppApp.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Helpers;
using System.Web.Http;

namespace GppApp.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        protected ICustomerService CustomerService { get; private set; }
        protected ILocationService LocationService { get; private set; }

        public CustomerController(ICustomerService customerService, ILocationService locationService)
        {
            CustomerService = customerService;
            LocationService = locationService;
        }

        // GET: api/Customer
        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                List<Customer> customers = await CustomerService.GetAllAsync();
                return Request.CreateResponse(HttpStatusCode.OK, customers.Select(x => new CustomerView(x)).ToList());
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }

        // GET: api/Customer/5
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            try
            {
                if (id == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
                Customer customer = await CustomerService.GetByIdAsync(id);

                if (customer == null) return Request.CreateResponse(HttpStatusCode.NotFound);
                return Request.CreateResponse(HttpStatusCode.OK, new CustomerView(customer));
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }

        // POST: api/Customer
        public async Task<HttpResponseMessage> Post([FromBody] CustomerView customer)
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
                bool success = await CustomerService.AddAsync(newCustomer);
                if (!success) return Request.CreateResponse(HttpStatusCode.BadRequest);
                return Request.CreateResponse(HttpStatusCode.OK, new CustomerView(newCustomer));
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }

        // PUT: api/Customer/5
        public async Task<HttpResponseMessage> Put(Guid id, [FromBody] PutCustomer customer)
        {
            try
            {
                if (id == null || customer == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
                Customer oldCustomer = await CustomerService.GetByIdAsync(id);
                if (oldCustomer == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

                if (customer.FirstName != null) oldCustomer.FirstName = customer.FirstName;
                if (customer.LastName != null) oldCustomer.LastName = customer.LastName;
                if (customer.Email != null) oldCustomer.Email = customer.Email;
                if (customer.PhoneNumber != null) oldCustomer.PhoneNumber = customer.PhoneNumber;

                oldCustomer.Location = new Location(customer.Location);

                bool result = await CustomerService.UpdateAsync(oldCustomer);

                if (!result) return Request.CreateResponse(HttpStatusCode.BadRequest);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }

        // DELETE: api/Customer/5
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            try
            {
                if (id == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
                bool result = await CustomerService.RemoveAsync(id);
                if (!result) return Request.CreateResponse(HttpStatusCode.BadRequest, "Not deleted");
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }
    }
}
