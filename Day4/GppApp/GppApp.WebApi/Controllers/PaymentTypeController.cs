using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GppApp.WebApi.Controllers
{
    public class PaymentTypeController : ApiController
    {
        public string ConnectionString { get => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }

        // GET: api/PaymentType
        //public HttpResponseMessage Get()
        //{
        //    List<PaymentTypeView> paymentTypes = new List<PaymentTypeView>();
        //    try
        //    {
        //        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        //        {
        //            string query = "SELECT * FROM \"PaymentType\"";
        //            NpgsqlCommand command = new NpgsqlCommand(query, connection);

        //            connection.Open();

        //            NpgsqlDataReader reader = command.ExecuteReader();

        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {
        //                    paymentTypes.Add(new PaymentTypeView
        //                    {
        //                        Name = Convert.ToString(reader["Name"])
        //                    });
        //                }
        //            }
        //        }
        //        return Request.CreateResponse(HttpStatusCode.OK, paymentTypes);
        //    }
        //    catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        //}

        //// GET: api/PaymentType/5
        //public HttpResponseMessage Get(Guid id)
        //{
        //    try
        //    {
        //        if (id == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        PaymentTypeView paymentType = null;
        //        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        //        {
        //            string query = "SELECT * FROM \"PaymentType\" WHERE \"Id\" = @id";
        //            NpgsqlCommand command = new NpgsqlCommand(query, connection);
        //            command.Parameters.AddWithValue("@id", id);

        //            connection.Open();

        //            NpgsqlDataReader reader = command.ExecuteReader();

        //            if (reader.HasRows && reader.Read())
        //            {
        //                paymentType = new PaymentTypeView
        //                {
        //                    Name = Convert.ToString(reader["Name"])
        //                };
        //            }
        //        }
        //        if (paymentType == null) return Request.CreateResponse(HttpStatusCode.NotFound);
        //        return Request.CreateResponse(HttpStatusCode.OK, paymentType);
        //    }
        //    catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        //}

        //// POST: api/PaymentType
        //public HttpResponseMessage Post([FromBody] PaymentTypeView paymentType)
        //{
        //    try
        //    {
        //        if (paymentType == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        int numberOfAffectedRows = 0;
        //        PaymentType newPaymentType = new PaymentType
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = paymentType.Name
        //        };
        //        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        //        {
        //            string query = "INSERT INTO \"PaymentType\" VALUES (@id, @name)";
        //            NpgsqlCommand command = new NpgsqlCommand(query, connection);
        //            command.Parameters.AddWithValue("@id", newPaymentType.Id);
        //            command.Parameters.AddWithValue("@name", newPaymentType.Name);

        //            connection.Open();

        //            numberOfAffectedRows = command.ExecuteNonQuery();
        //        }
        //        if (numberOfAffectedRows == 0) return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        //}

        //// PUT: api/PaymentType/5
        //public HttpResponseMessage Put(Guid id, [FromBody] PaymentTypeView paymentType)
        //{
        //    try
        //    {
        //        if(id == null || paymentType == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        int numberOfAffectedRows = 0;
        //        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        //        {
        //            string query = "UPDATE \"PaymentType\" set \"Name\" = @name WHERE \"Id\" = @id";
        //            NpgsqlCommand command = new NpgsqlCommand(query, connection);
        //            command.Parameters.AddWithValue("@id", id);
        //            command.Parameters.AddWithValue("@name", paymentType.Name);

        //            connection.Open();
        //            numberOfAffectedRows = command.ExecuteNonQuery();
        //        }
        //        if (numberOfAffectedRows == 0) return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        //}

        //// DELETE: api/PaymentType/5
        //public HttpResponseMessage Delete(Guid id)
        //{
        //    try
        //    {
        //        if(id == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        int numberOfAffectedRows = 0;
        //        using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
        //        {
        //            string query = "DELETE FROM \"PaymentType\" where \"Id\" = @id";
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
