using GppApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GppApp.Repository.Common
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetAllAsync();

        /// <summary>
        /// Getting the location by Id
        /// </summary>
        /// <param name="id">The location's Id</param>
        /// <returns>The location object, null if not found</returns>
        Task<Location> GetByIdAsync(Guid id);

        /// <summary>
        /// Getting the location by it's parameters
        /// </summary>
        /// <param name="location">The location for which to search a record in the database</param>
        /// <returns>The location object, null if not found</returns>
        Task<Location> GetAsync(Location location);

        Task<bool> AddAsync(Location location);

        Task<bool> UpdateAsync(Location location);
    }
}
