using GppApp.WebApi.Models;
using GppApp.WebApi.ViewModels;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace GppApp.WebApi.Services
{
    public class LocationService
    {
        public string ConnectionString { get => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }

        public List<Location> GetAll()
        {
            List<Location> locations = new List<Location>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM \"Location\"";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.HasRows && reader.Read())
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
        public Location GetById(Guid id)
        {
            if (id == null) return null;
            Location location = null;
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM \"Location\" where \"Id\" = @id";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                NpgsqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows && reader.Read())
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
        public Location Get(LocationView location)
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

                connection.Open();

                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
                    oldLocation = ReadLocation(reader);
                }
            }
            return oldLocation;
        }

        public Location Add(LocationView location)
        {
            if(location == null) return null;
            Location newLocation = new Location()
            {
                Id = Guid.NewGuid(),
                Address = location.Address,
                City = location.City,
                Country = location.Country,
                ZipCode = location.ZipCode
            };
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                string locationQuery = "INSERT INTO \"Location\" VALUES (@id, @country, @city, @address, @zipCode)";
                NpgsqlCommand locationCommand = new NpgsqlCommand(locationQuery, connection);
                locationCommand.Parameters.AddWithValue("@id", newLocation.Id);
                locationCommand.Parameters.AddWithValue("@country", newLocation.Country);
                locationCommand.Parameters.AddWithValue("@city", newLocation.City);
                locationCommand.Parameters.AddWithValue("@address", newLocation.Address);
                locationCommand.Parameters.AddWithValue("@zipCode", newLocation.ZipCode);

                connection.Open();

                if (locationCommand.ExecuteNonQuery() == 0) return null;
            }
            return newLocation;
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