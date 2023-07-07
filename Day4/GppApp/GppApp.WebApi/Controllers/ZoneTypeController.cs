using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GppApp.WebApi.Controllers
{
    public class ZoneTypeController : ApiController
    {
        public string ConnectionString { get => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }

        // GET: api/ZoneType
        //public HttpResponseMessage Get()
        //{
        //    List<ZoneTypeView> zoneTypes = new List<ZoneTypeView>();
        //    try
        //    {
        //        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        //        {
        //            string query = "SELECT * FROM \"ZoneType\"";
        //            NpgsqlCommand command = new NpgsqlCommand(query, connection);

        //            connection.Open();

        //            NpgsqlDataReader reader = command.ExecuteReader();

        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {
        //                    zoneTypes.Add(new ZoneTypeView
        //                    {
        //                        Name = Convert.ToString(reader["Name"])
        //                    });
        //                }
        //            }
        //        }
        //        return Request.CreateResponse(HttpStatusCode.OK, zoneTypes);
        //    }
        //    catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        //}

        //// GET: api/ZoneType/5
        //public HttpResponseMessage Get(Guid id)
        //{
        //    try
        //    {
        //        if (id == null) return Request.CreateResponse(HttpStatusCode.NotFound);
        //        ZoneTypeView zoneType = null;
        //        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        //        {
        //            string query = "SELECT * FROM \"ZoneType\" WHERE \"Id\" = @id";
        //            NpgsqlCommand command = new NpgsqlCommand(query, connection);
        //            command.Parameters.AddWithValue("@id", id);

        //            connection.Open();

        //            NpgsqlDataReader reader = command.ExecuteReader();

        //            if (reader.HasRows && reader.Read())
        //            {
        //                zoneType = new ZoneTypeView
        //                {
        //                    Name = Convert.ToString(reader["Name"])
        //                };
        //            }
        //        }
        //        if (zoneType == null) return Request.CreateResponse(HttpStatusCode.NotFound);
        //        return Request.CreateResponse(HttpStatusCode.OK, zoneType);
        //    }
        //    catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        //}

        //// POST: api/ZoneType
        //public HttpResponseMessage Post([FromBody] ZoneTypeView zoneType)
        //{
        //    try
        //    {
        //        if (zoneType == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        int numberOfAffectedRows = 0;
        //        ZoneType newZoneType = new ZoneType
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = zoneType.Name
        //        };
        //        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        //        {
        //            string query = "INSERT INTO \"ZoneType\" VALUES (@id, @name)";
        //            NpgsqlCommand command = new NpgsqlCommand(query, connection);
        //            command.Parameters.AddWithValue("@id", newZoneType.Id);
        //            command.Parameters.AddWithValue("@name", newZoneType.Name);

        //            connection.Open();

        //            numberOfAffectedRows = command.ExecuteNonQuery();
        //        }
        //        if (numberOfAffectedRows == 0) return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        //}

        //// PUT: api/ZoneType/5
        //public HttpResponseMessage Put(Guid id, [FromBody] ZoneTypeView zoneType)
        //{
        //    try
        //    {
        //        if (id == null || zoneType == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        int numberOfAffectedRows = 0;
        //        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        //        {
        //            string query = "UPDATE \"ZoneType\" set \"Name\" = @name WHERE \"Id\" = @id";
        //            NpgsqlCommand command = new NpgsqlCommand(query, connection);
        //            command.Parameters.AddWithValue("@id", id);
        //            command.Parameters.AddWithValue("@name", zoneType.Name);

        //            connection.Open();
        //            numberOfAffectedRows = command.ExecuteNonQuery();
        //        }
        //        if(numberOfAffectedRows == 0) return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        //}

        //// DELETE: api/ZoneType/5
        //public HttpResponseMessage Delete(Guid id)
        //{
        //    try
        //    {
        //        if (id == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        int numberOfAffectedRows = 0;
        //        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        //        {
        //            string query = "DELETE FROM \"ZoneType\" where \"Id\" = @id";
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
    }
}
