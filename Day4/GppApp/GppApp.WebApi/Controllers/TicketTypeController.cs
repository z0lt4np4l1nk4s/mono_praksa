using GppApp.WebApi.Models;
using GppApp.WebApi.ViewModels;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GppApp.WebApi.Controllers
{
    public class TicketTypeController : ApiController
    {
        public string ConnectionString { get => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }

        // GET: api/TicketType
        public HttpResponseMessage Get()
        {
            List<TicketTypeView> ticketTypes = new List<TicketTypeView>();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM \"TicketType\"";
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);

                    connection.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ticketTypes.Add(new TicketTypeView
                            {
                                Name = Convert.ToString(reader["Name"])
                            });
                        }
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, ticketTypes);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }

        // GET: api/TicketType/5
        public HttpResponseMessage Get(Guid id)
        {
            try
            {
                if (id == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
                TicketTypeView ticketType = null;
                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM \"TicketType\" WHERE \"Id\" = @id";
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        ticketType = new TicketTypeView
                        {
                            Name = Convert.ToString(reader["Name"])
                        };
                    }
                }
                if (ticketType == null) return Request.CreateResponse(HttpStatusCode.NotFound);
                return Request.CreateResponse(HttpStatusCode.OK, ticketType);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }

        // POST: api/TicketType
        public HttpResponseMessage Post([FromBody] TicketTypeView ticketType)
        {
            try
            {
                if (ticketType == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
                int numberOfAffectedRows = 0;
                TicketType newTicketType = new TicketType
                {
                    Id = Guid.NewGuid(),
                    Name = ticketType.Name
                };
                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
                {
                    string query = "INSERT INTO \"TicketType\" VALUES (@id, @name)";
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", newTicketType.Id);
                    command.Parameters.AddWithValue("@name", newTicketType.Name);

                    connection.Open();

                    numberOfAffectedRows = command.ExecuteNonQuery();
                }
                if (numberOfAffectedRows == 0) return Request.CreateResponse(HttpStatusCode.BadRequest);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }

        // PUT: api/TicketType/5
        public HttpResponseMessage Put(Guid id, [FromBody] TicketTypeView ticketType)
        {
            try
            {
                if (id == null || ticketType == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
                int numberOfAffectedRows = 0;
                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
                {
                    string query = "UPDATE \"TicketType\" set \"Name\" = @name WHERE \"Id\" = @id";
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", ticketType.Name);

                    connection.Open();
                    numberOfAffectedRows = command.ExecuteNonQuery();
                }
                if (numberOfAffectedRows == 0) return Request.CreateResponse(HttpStatusCode.BadRequest);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }

        // DELETE: api/TicketType/5
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                if (id == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
                int numberOfAffectedRows = 0;
                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
                {
                    string query = "DELETE FROM \"TicketType\" where \"Id\" = @id";
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
    }
}
