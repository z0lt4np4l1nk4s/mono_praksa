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
using System.Web.Http;

namespace GppApp.WebApi.Controllers
{
    public class LocationController : ApiController
    {
        public string ConnectionString { get => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
        private LocationService locationService;

        public LocationController()
        {
            locationService = new LocationService();
        }

        // GET: api/Location
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, locationService.GetAll());
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }

        // GET: api/Location/5
        public HttpResponseMessage Get(Guid id)
        {
            try
            {
                if (id == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
                Location location = locationService.GetById(id);
                if (location == null) return Request.CreateResponse(HttpStatusCode.NotFound);
                return Request.CreateResponse(HttpStatusCode.OK, location);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }

        // POST: api/Location
        public HttpResponseMessage Post([FromBody] LocationView location)
        {
            try
            {
                if (location == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
                if (locationService.Add(location) == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
                return Request.CreateResponse(HttpStatusCode.OK, location);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }

        // PUT: api/Location/5
        public HttpResponseMessage Put(Guid id, [FromBody] LocationView location)
        {
            try
            {
                if (id == null || location == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
                int numberOfAffectedRows = 0;
                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
                {
                    string query = "UPDATE \"Location\" set \"Country\" = @country, \"City\" = @city, \"Address\" = @address, \"ZipCode\" = @zipCode WHERE \"Id\" = @id";
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@country", location.Country);
                    command.Parameters.AddWithValue("@city", location.City);
                    command.Parameters.AddWithValue("@address", location.Address);
                    command.Parameters.AddWithValue("@zipCode", location.ZipCode);

                    connection.Open();
                    numberOfAffectedRows = command.ExecuteNonQuery();
                }
                if (numberOfAffectedRows == 0) return Request.CreateResponse(HttpStatusCode.BadRequest);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }
    }
}
