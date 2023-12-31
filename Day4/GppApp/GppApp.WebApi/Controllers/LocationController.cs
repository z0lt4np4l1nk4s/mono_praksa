﻿using GppApp.Model;
using GppApp.Service;
using GppApp.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GppApp.WebApi.Controllers
{
    public class LocationController : ApiController
    {
        private readonly ILocationService iLocationService;

        public LocationController()
        {
            iLocationService = new LocationService();
        }

        // GET: api/Location
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, iLocationService.GetAll().Select(x => new LocationView(x)));
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }

        // GET: api/Location/5
        public HttpResponseMessage Get(Guid id)
        {
            try
            {
                if (id == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
                Location location = iLocationService.GetById(id);
                if (location == null) return Request.CreateResponse(HttpStatusCode.NotFound);
                return Request.CreateResponse(HttpStatusCode.OK, new LocationView(location));
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }

        // POST: api/Location
        public HttpResponseMessage Post([FromBody] LocationView location)
        {
            try
            {
                if (location == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
                Location newLocation = new Location(location);
                newLocation.Id = Guid.NewGuid();

                bool result = iLocationService.Add(newLocation);

                if (!result) return Request.CreateResponse(HttpStatusCode.BadRequest);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }

        // PUT: api/Location/5
        public HttpResponseMessage Put(Guid id, [FromBody] LocationView location)
        {
            try
            {
                if (id == null || location == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
                Location newLocation = new Location(location);
                newLocation.Id = id;

                bool result = iLocationService.Update(newLocation);

                if (!result) return Request.CreateResponse(HttpStatusCode.BadRequest);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError, "Code crash"); }
        }
    }
}
