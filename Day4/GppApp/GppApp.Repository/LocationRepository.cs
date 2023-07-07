using GppApp.Model;
using GppApp.Repository.Common;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GppApp.Repository
{
    public class LocationRepository : ILocationRepository
    {
        public string ConnectionString { get => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }

        public async Task<List<Location>> GetAllAsync()
        {
            List<Location> locations = new List<Location>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM \"Location\"";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                await connection.OpenAsync();

                NpgsqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.HasRows && await reader.ReadAsync())
                {
                    locations.Add(ReadLocation(reader));
                }
            }
            return locations;
        }

        /// <summary>
        /// Getting the location by Id
        /// </summary>
        /// <param name="id">The location's Id</param>
        /// <returns>The location object, null if not found</returns>
        public async Task<Location> GetByIdAsync(Guid id)
        {
            if (id == null) return null;
            Location location = null;
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM \"Location\" where \"Id\" = @id";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                await connection.OpenAsync();

                NpgsqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows && await reader.ReadAsync())
                {
                    location = ReadLocation(reader);
                }
            }
            return location;
        }

        /// <summary>
        /// Getting the location by it's parameters
        /// </summary>
        /// <param name="location">The location for which to search a record in the database</param>
        /// <returns>The location object, null if not found</returns>
        public async Task<Location> GetAsync(Location location)
        {
            if (location == null) return null;
            Location oldLocation = null;
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM \"Location\" where \"Address\" = @address and \"City\" = @city and \"Country\" = @country and \"ZipCode\" = @zipCode";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@address", location.Address);
                command.Parameters.AddWithValue("@city", location.City);
                command.Parameters.AddWithValue("@country", location.Country);
                command.Parameters.AddWithValue("@zipCode", location.ZipCode);

                await connection.OpenAsync();

                NpgsqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows && await reader.ReadAsync())
                {
                    oldLocation = ReadLocation(reader);
                }
            }
            return oldLocation;
        }

        public async Task<bool> AddAsync(Location location)
        {
            Location newLocation = new Location()
            {
                Id = Guid.NewGuid(),
                Address = location.Address,
                City = location.City,
                Country = location.Country,
                ZipCode = location.ZipCode
            };
            int numberOfAffectedRows = 0;
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                string locationQuery = "INSERT INTO \"Location\" VALUES (@id, @country, @city, @address, @zipCode)";
                NpgsqlCommand locationCommand = new NpgsqlCommand(locationQuery, connection);
                locationCommand.Parameters.AddWithValue("@id", newLocation.Id);
                locationCommand.Parameters.AddWithValue("@country", newLocation.Country);
                locationCommand.Parameters.AddWithValue("@city", newLocation.City);
                locationCommand.Parameters.AddWithValue("@address", newLocation.Address);
                locationCommand.Parameters.AddWithValue("@zipCode", newLocation.ZipCode);

                await connection.OpenAsync();

                numberOfAffectedRows = await locationCommand.ExecuteNonQueryAsync();
            }
            return numberOfAffectedRows != 0;
        }

        public async Task<bool> UpdateAsync(Location location)
        {
            int numberOfAffectedRows = 0;
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                string query = "UPDATE \"Location\" set \"Country\" = @country, \"City\" = @city, \"Address\" = @address, \"ZipCode\" = @zipCode WHERE \"Id\" = @id";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", location.Id);
                command.Parameters.AddWithValue("@country", location.Country);
                command.Parameters.AddWithValue("@city", location.City);
                command.Parameters.AddWithValue("@address", location.Address);
                command.Parameters.AddWithValue("@zipCode", location.ZipCode);

                await connection.OpenAsync();

                numberOfAffectedRows = await command.ExecuteNonQueryAsync();
            }
            return numberOfAffectedRows != 0;
        }

        private Location ReadLocation(NpgsqlDataReader reader)
        {
            try
            {
                return new Location
                {
                    Id = (Guid)reader["Id"],
                    Address = Convert.ToString(reader["Address"]),
                    City = Convert.ToString(reader["City"]),
                    Country = Convert.ToString(reader["Country"]),
                    ZipCode = Convert.ToString(reader["ZipCode"])
                };
            }
            catch { return null; }
        }
    }
}
