using GppApp.WebApi.Models;
using GppApp.WebApi.Services;
using GppApp.WebApi.ViewModels;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace GppApp.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        public string ConnectionString { get => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
        private readonly LocationService locationService;

        public CustomerController()
        {
            locationService = new LocationService();
        }

        // GET: api/Customer
        public HttpResponseMessage Get()
        {
            List<CustomerView> customers = new List<CustomerView>();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM \"Customer\" c INNER JOIN \"User\" u ON c.\"Id\" = u.\"Id\" INNER JOIN \"Location\" l ON u.\"LocationId\" = l.\"Id\";";
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);

                    connection.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            customers.Add(ReadCustomer(reader));
                        }
                    }
                }
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
                CustomerView customer = null;
                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM \"Customer\" c INNER JOIN \"User\" u ON c.\"Id\" = u.\"Id\" INNER JOIN \"Location\" l ON u.\"LocationId\" = l.\"Id\" WHERE \"Id\" = @id;";
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        customer = ReadCustomer(reader);
                    }
                }
                if (customer == null) return Request.CreateResponse(HttpStatusCode.NotFound);
                return Request.CreateResponse(HttpStatusCode.OK, customer);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }

        // POST: api/Customer
        public HttpResponseMessage Post([FromBody] CustomerView customer)
        {
            try
            {
                int numberOfAffectedRows = 0;
                if (customer == null || customer.Location == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
                Location newLocation = locationService.Get(customer.Location);

                if (newLocation == null) newLocation = locationService.Add(customer.Location);

                Customer newCustomer = new Customer
                {
                    Id = Guid.NewGuid(),
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    DateOfBirth = customer.DateOfBirth,
                    RegisterDate = DateTime.UtcNow,
                    LocationId = newLocation.Id,
                    Location = newLocation
                };

                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
                {                    

                    string customerQuery = "INSERT INTO \"User\" VALUES (@id, @firstName, @lastName, @email, @phoneNumber, @dateOfBirth, @locationId);" +
                        "INSERT INTO \"Customer\" VALUES (@id, @registerDate);";
                    NpgsqlCommand customerCommand = new NpgsqlCommand(customerQuery, connection);
                    customerCommand.Parameters.AddWithValue("@id", newCustomer.Id);
                    customerCommand.Parameters.AddWithValue("@firstName", newCustomer.FirstName);
                    customerCommand.Parameters.AddWithValue("@lastName", newCustomer.LastName);
                    customerCommand.Parameters.AddWithValue("@email", newCustomer.Email);
                    customerCommand.Parameters.AddWithValue("@phoneNumber", newCustomer.PhoneNumber);
                    customerCommand.Parameters.AddWithValue("@dateOfBirth", newCustomer.DateOfBirth);
                    customerCommand.Parameters.AddWithValue("@locationId", newLocation.Id);
                    customerCommand.Parameters.AddWithValue("@registerDate", newCustomer.RegisterDate);

                    connection.Open();

                    numberOfAffectedRows = customerCommand.ExecuteNonQuery();
                    if (numberOfAffectedRows == 0) return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
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
                int numberOfAffectedRows = 0;
                Location location = locationService.Get(customer.Location);
                if (location == null && customer.Location != null) location = locationService.Add(customer.Location);
                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
                {
                    NpgsqlCommand command = new NpgsqlCommand();
                    List<string> updatedValues = new List<string>();
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@id", id);

                    if (customer.FirstName != null)
                    {
                        updatedValues.Add("\"FirstName\" = @firstName");
                        command.Parameters.AddWithValue("@firstName", customer.FirstName);
                    }

                    if (customer.LastName != null)
                    {
                        updatedValues.Add("\"LastName\" = @lastName");
                        command.Parameters.AddWithValue("@lastName", customer.LastName);
                    }

                    if (customer.Email != null)
                    {
                        updatedValues.Add("\"Email\" = @email");
                        command.Parameters.AddWithValue("@email", customer.Email);
                    }

                    if (customer.PhoneNumber != null)
                    {
                        updatedValues.Add("\"PhoneNumber\" = @phoneNumber");
                        command.Parameters.AddWithValue("@phoneNumber", customer.PhoneNumber);
                    }

                    if (location != null)
                    {
                        updatedValues.Add("\"LocationId\" = @locationId");
                        command.Parameters.AddWithValue("@locationId", location.Id);
                    }

                    command.CommandText = "UPDATE \"User\" SET " + string.Join(", ", updatedValues) + " WHERE \"Id\" = @id";

                    connection.Open();
                    numberOfAffectedRows = command.ExecuteNonQuery();
                }
                if (numberOfAffectedRows == 0) return Request.CreateResponse(HttpStatusCode.BadRequest);
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
                int numberOfAffectedRows = 0;
                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
                {
                    string query = "DELETE FROM \"Customer\" where \"Id\" = @id; DELETE FROM \"User\" where \"Id\" = @id";
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    numberOfAffectedRows = command.ExecuteNonQuery();
                }
                if (numberOfAffectedRows == 0) return Request.CreateResponse(HttpStatusCode.BadRequest, "Not deleted");
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }

        private CustomerView ReadCustomer(NpgsqlDataReader reader)
        {
            try
            {
                return new CustomerView()
                {
                    FirstName = Convert.ToString(reader["FirstName"]),
                    LastName = Convert.ToString(reader["LastName"]),
                    Email = Convert.ToString(reader["Email"]),
                    PhoneNumber = Convert.ToString(reader["PhoneNumber"]),
                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                    RegisterDate = Convert.ToDateTime(reader["RegisterDate"]),
                    Location = new LocationView
                    {
                        Address = Convert.ToString(reader["Address"]),
                        City = Convert.ToString(reader["City"]),
                        Country = Convert.ToString(reader["Country"]),
                        ZipCode = Convert.ToString(reader["ZipCode"])
                    }
                };
            }
            catch { return null; }
        }
    }
}
