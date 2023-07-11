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

        public LocationService(ILocationRepository locationRepository)
        {
            repo = locationRepository;
        }

        public async Task<List<Location>> GetAllAsync() => await repo.GetAllAsync();

        /// <summary>
        /// Getting the location by Id
        /// </summary>
        /// <param name="id">The location's Id</param>
        /// <returns>The location object, null if not found</returns>
        public async Task<Location> GetByIdAsync(Guid id) => await repo.GetByIdAsync(id);

        /// <summary>
        /// Getting the location by it's parameters
        /// </summary>
        /// <param name="location">The location for which to search a record in the database</param>
        /// <returns>The location object, null if not found</returns>
        public async Task<Location> GetAsync(Location location) => await repo.GetAsync(location);

        public async Task<bool> AddAsync(Location location) => await repo.AddAsync(location);

        public async Task<bool> UpdateAsync(Location location) => await repo.UpdateAsync(location);

        public async Task<bool> Any(Guid id) => await repo.GetByIdAsync(id) != null;
    }
}
