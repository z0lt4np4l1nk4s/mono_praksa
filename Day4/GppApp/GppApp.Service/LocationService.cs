using GppApp.Model;
using GppApp.Repository;
using GppApp.Repository.Common;
using GppApp.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GppApp.Service
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository repo;

        public LocationService()
        {
            repo = new LocationRepository();
        }

        public List<Location> GetAll() => repo.GetAll();

        /// <summary>
        /// Getting the location by Id
        /// </summary>
        /// <param name="id">The location's Id</param>
        /// <returns>The location object, null if not found</returns>
        public Location GetById(Guid id) => repo.GetById(id);

        /// <summary>
        /// Getting the location by it's parameters
        /// </summary>
        /// <param name="location">The location for which to search a record in the database</param>
        /// <returns>The location object, null if not found</returns>
        public Location Get(Location location) => repo.Get(location);

        public bool Add(Location location) => repo.Add(location);

        public bool Update(Location location) => repo.Update(location);
    }
}
