using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GppApp.WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        public string ConnectionString { get => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
        //private readonly LocationService locationService;

        //public EmployeeController()
        //{
        //    locationService = new LocationService();
        //}

        //// GET: api/Employee
        //public HttpResponseMessage Get()
        //{
        //    List<EmployeeView> customers = new List<EmployeeView>();
        //    try
        //    {
        //        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        //        {
        //            string query = "SELECT * FROM \"Employee\" e INNER JOIN \"User\" u ON e.\"Id\" = u.\"Id\" INNER JOIN \"Location\" l ON u.\"LocationId\" = l.\"Id\";";
        //            NpgsqlCommand command = new NpgsqlCommand(query, connection);

        //            connection.Open();

        //            NpgsqlDataReader reader = command.ExecuteReader();

        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {
        //                    customers.Add(ReadEmployee(reader));
        //                }
        //            }
        //        }
        //        return Request.CreateResponse(HttpStatusCode.OK, customers);
        //    }
        //    catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        //}

        //// GET: api/Employee/5
        //public HttpResponseMessage Get(Guid id)
        //{
        //    try
        //    {
        //        if (id == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        EmployeeView employee = null;
        //        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        //        {
        //            string query = "SELECT * FROM \"Employee\" e INNER JOIN \"User\" u ON e.\"Id\" = u.\"Id\" INNER JOIN \"Location\" l ON u.\"LocationId\" = l.\"Id\" WHERE \"Id\" = @id;";
        //            NpgsqlCommand command = new NpgsqlCommand(query, connection);
        //            command.Parameters.AddWithValue("@id", id);

        //            connection.Open();

        //            NpgsqlDataReader reader = command.ExecuteReader();

        //            if (reader.HasRows && reader.Read())
        //            {
        //                employee = ReadEmployee(reader);
        //            }
        //        }
        //        if (employee == null) return Request.CreateResponse(HttpStatusCode.NotFound);
        //        return Request.CreateResponse(HttpStatusCode.OK, employee);
        //    }
        //    catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        //}

        //// POST: api/Employee
        //public HttpResponseMessage Post([FromBody] EmployeeView employee)
        //{
        //    try
        //    {
        //        int numberOfAffectedRows = 0;
        //        if (employee == null || employee.Location == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        Location newLocation = locationService.Get(employee.Location);

        //        if (newLocation == null) newLocation = locationService.Add(employee.Location);

        //        Employee newEmployee = new Employee
        //        {
        //            Id = Guid.NewGuid(),
        //            FirstName = employee.FirstName,
        //            LastName = employee.LastName,
        //            Email = employee.Email,
        //            PhoneNumber = employee.PhoneNumber,
        //            DateOfBirth = employee.DateOfBirth,
        //            JoinDate = DateTime.UtcNow,
        //            Department = employee.Department,
        //            LocationId = newLocation.Id,
        //            Location = newLocation
        //        };

        //        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        //        {

        //            string customerQuery = "INSERT INTO \"User\" VALUES (@id, @firstName, @lastName, @email, @phoneNumber, @dateOfBirth, @locationId);" +
        //                "INSERT INTO \"Employee\" VALUES (@id, @department, @joinDate);";
        //            NpgsqlCommand customerCommand = new NpgsqlCommand(customerQuery, connection);
        //            customerCommand.Parameters.AddWithValue("@id", newEmployee.Id);
        //            customerCommand.Parameters.AddWithValue("@firstName", newEmployee.FirstName);
        //            customerCommand.Parameters.AddWithValue("@lastName", newEmployee.LastName);
        //            customerCommand.Parameters.AddWithValue("@email", newEmployee.Email);
        //            customerCommand.Parameters.AddWithValue("@phoneNumber", newEmployee.PhoneNumber);
        //            customerCommand.Parameters.AddWithValue("@dateOfBirth", newEmployee.DateOfBirth);
        //            customerCommand.Parameters.AddWithValue("@locationId", newLocation.Id);
        //            customerCommand.Parameters.AddWithValue("@joinDate", newEmployee.JoinDate);
        //            customerCommand.Parameters.AddWithValue("@department", newEmployee.Department);

        //            connection.Open();

        //            numberOfAffectedRows = customerCommand.ExecuteNonQuery();
        //            if (numberOfAffectedRows == 0) return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        }
        //        return Request.CreateResponse(HttpStatusCode.OK, new EmployeeView(newEmployee));
        //    }
        //    catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        //}

        //// PUT: api/Employee/5
        //public HttpResponseMessage Put(Guid id, [FromBody] PutEmployee employee)
        //{
        //    try
        //    {
        //        if (id == null || employee == null || employee.Location == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        int numberOfAffectedRows = 0;
        //        Location location = locationService.Get(employee.Location);
        //        if (location == null) location = locationService.Add(employee.Location);
        //        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        //        {
        //            string query = "UPDATE \"User\" set \"FirstName\" = @firstName, \"LastName\" = @lastName, \"Email\" = @email, \"PhoneNumber\" = @phoneNumber, \"LocationId\" = @locationId WHERE \"Id\" = @id;" +
        //                "UPDATE \"Employee\" set \"Department\" = @department WHERE \"Id\" = @id";
        //            NpgsqlCommand command = new NpgsqlCommand(query, connection);
        //            command.Parameters.AddWithValue("@id", id);
        //            command.Parameters.AddWithValue("@firstName", employee.FirstName);
        //            command.Parameters.AddWithValue("@lastName", employee.LastName);
        //            command.Parameters.AddWithValue("@email", employee.Email);
        //            command.Parameters.AddWithValue("@phoneNumber", employee.PhoneNumber);
        //            command.Parameters.AddWithValue("@department", employee.Department);
        //            command.Parameters.AddWithValue("@locationId", location.Id);

        //            connection.Open();
        //            numberOfAffectedRows = command.ExecuteNonQuery();
        //        }
        //        if (numberOfAffectedRows == 0) return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        //}

        //// DELETE: api/Employee/5
        //public HttpResponseMessage Delete(Guid id)
        //{
        //    try
        //    {
        //        if (id == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        int numberOfAffectedRows = 0;
        //        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        //        {
        //            string query = "DELETE FROM \"Employee\" where \"Id\" = @id; DELETE FROM \"User\" where \"Id\" = @id";
        //            NpgsqlCommand command = new NpgsqlCommand(query, connection);
        //            command.Parameters.AddWithValue("@id", id);

        //            connection.Open();

        //            numberOfAffectedRows = command.ExecuteNonQuery();
        //        }
        //        if (numberOfAffectedRows == 0) return Request.CreateResponse(HttpStatusCode.BadRequest, "Not deleted");
        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        //}

        //private EmployeeView ReadEmployee(NpgsqlDataReader reader)
        //{
        //    try
        //    {
        //        return new EmployeeView()
        //        {
        //            FirstName = Convert.ToString(reader["FirstName"]),
        //            LastName = Convert.ToString(reader["LastName"]),
        //            Email = Convert.ToString(reader["Email"]),
        //            PhoneNumber = Convert.ToString(reader["PhoneNumber"]),
        //            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
        //            JoinDate = Convert.ToDateTime(reader["JoinDate"]),
        //            Department = Convert.ToString(reader["Customer"]),
        //            Location = new LocationView
        //            {
        //                Address = Convert.ToString(reader["Address"]),
        //                City = Convert.ToString(reader["City"]),
        //                Country = Convert.ToString(reader["Country"]),
        //                ZipCode = Convert.ToString(reader["ZipCode"])
        //            }
        //        };
        //    }
        //    catch { return null; }
        //}
    }
}
