using GppApp.Common;
using GppApp.Common.Filters;
using GppApp.Model;
using GppApp.Repository.Common;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GppApp.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public string ConnectionString { get => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }

        public async Task<PagedList<Customer>> GetAllAsync(Sorting sorting, Paging paging, CustomerFilter customerFilter)
        {
            PagedList<Customer> pagedList = new PagedList<Customer>();
            if (paging == null) paging = new Paging();
            if (sorting == null) sorting = new Sorting();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = connection;
                command.Parameters.AddWithValue("@pageSize", paging.PageSize);
                command.Parameters.AddWithValue("@skip", (paging.CurrentPage - 1) * paging.PageSize);

                string sortBy = (sorting.SortBy.ToLower() == "RegisterDate".ToLower() ? "" : "u.") + "\"" + sorting.SortBy + "\"";

                List<string> parameters = new List<string>();

                if (customerFilter != null)
                {

                    if (customerFilter.FirstName != null)
                    {
                        parameters.Add("LOWER(u.\"FirstName\") LIKE @firstName");
                        command.Parameters.AddWithValue("@firstName", "%" + customerFilter.FirstName.ToLower() + "%");
                    }

                    if (customerFilter.LastName != null)
                    {
                        parameters.Add("LOWER(u.\"LastName\") LIKE @lastName");
                        command.Parameters.AddWithValue("@lastName", "%" + customerFilter.LastName.ToLower() + "%");
                    }

                    if (customerFilter.MinAge != null)
                    {
                        parameters.Add("DATE_PART('year', age(NOW(), u.\"DateOfBirth\")) >= @minAge");
                        command.Parameters.AddWithValue("@minAge", customerFilter.MinAge);
                    }

                    if (customerFilter.MaxAge != null)
                    {
                        parameters.Add("DATE_PART('year', age(NOW(), u.\"DateOfBirth\")) <= @maxAge");
                        command.Parameters.AddWithValue("@maxAge", customerFilter.MaxAge);
                    }

                    if (customerFilter.City != null)
                    {
                        parameters.Add("LOWER(l.\"City\") LIKE @city");
                        command.Parameters.AddWithValue("@city", "%" + customerFilter.City.ToLower() + "%");
                    }

                    if (customerFilter.Country != null)
                    {
                        parameters.Add("LOWER(l.\"Country\") LIKE @country");
                        command.Parameters.AddWithValue("@country", "%" + customerFilter.Country.ToLower() + "%");
                    }

                    if (customerFilter.ZipCode != null)
                    {
                        parameters.Add("LOWER(l.\"ZipCode\") LIKE @zipCode");
                        command.Parameters.AddWithValue("@zipCode", "%" + customerFilter.ZipCode.ToLower() + "%");
                    }

                    if (customerFilter.RegisterDateStart != null)
                    {
                        parameters.Add("c.\"RegisterDate\" >= @registerDateStart");
                        command.Parameters.AddWithValue("@registerDateStart", customerFilter.RegisterDateStart.Value);
                    }

                    if (customerFilter.RegisterDateEnd != null)
                    {
                        parameters.Add("c.\"RegisterDate\" <= @registerDateEnd");
                        command.Parameters.AddWithValue("@registerDateEnd", customerFilter.RegisterDateEnd.Value);
                    }
                }

                string selectQuery = "SELECT * FROM \"Customer\" c INNER JOIN \"User\" u ON c.\"Id\" = u.\"Id\" INNER JOIN \"Location\" l ON u.\"LocationId\" = l.\"Id\" " +
                    (parameters.Count == 0 ? "" : " WHERE " + string.Join(" and ", parameters)) +
                    $" ORDER BY {sortBy} {(sorting.SortOrder.ToLower() == "asc" ? "ASC" : "DESC")} LIMIT @pageSize OFFSET @skip;";

                string countQuery = "SELECT COUNT(*) FROM \"Customer\"" + (parameters.Count == 0 ? "" : " WHERE " + string.Join(" and ", parameters));
                NpgsqlCommand countCommand = new NpgsqlCommand(countQuery, connection);

                foreach (NpgsqlParameter npgsqlParameter in command.Parameters) countCommand.Parameters.AddWithValue(npgsqlParameter.ParameterName, npgsqlParameter.Value);

                command.CommandText = selectQuery;

                await connection.OpenAsync();

                object countResult = await countCommand.ExecuteScalarAsync();

                NpgsqlDataReader reader = await command.ExecuteReaderAsync();

                if (countResult == null || !reader.HasRows) return null;

                while (reader.HasRows && await reader.ReadAsync())
                {
                    pagedList.Data.Add(ReadCustomer(reader));
                }

                pagedList.CurrentPage = paging.CurrentPage;
                pagedList.PageSize = paging.PageSize;
                pagedList.ItemCount = Convert.ToInt32(countResult);
                pagedList.LastPage = Convert.ToInt32(pagedList.ItemCount / paging.PageSize) + (pagedList.ItemCount % paging.PageSize != 0 ? 1 : 0);
            }
            return pagedList;
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            Customer customer = null;
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM \"Customer\" c INNER JOIN \"User\" u ON c.\"Id\" = u.\"Id\" INNER JOIN \"Location\" l ON u.\"LocationId\" = l.\"Id\" WHERE c.\"Id\" = @id;";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                await connection.OpenAsync();

                NpgsqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows && await reader.ReadAsync())
                {
                    customer = ReadCustomer(reader);
                }
            }
            return customer;
        }

        public async Task<bool> AddAsync(Customer customer)
        {
            bool succeded = false;

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                string userQuery = "INSERT INTO \"User\" VALUES (@id, @firstName, @lastName, @email, @phoneNumber, @dateOfBirth, @locationId);";
                string customerQuery = "INSERT INTO \"Customer\" VALUES (@id, @registerDate);";
                NpgsqlCommand userCommand = new NpgsqlCommand(userQuery, connection);
                userCommand.Parameters.AddWithValue("@id", customer.Id);
                userCommand.Parameters.AddWithValue("@firstName", customer.FirstName);
                userCommand.Parameters.AddWithValue("@lastName", customer.LastName);
                userCommand.Parameters.AddWithValue("@email", customer.Email);
                userCommand.Parameters.AddWithValue("@phoneNumber", customer.PhoneNumber);
                userCommand.Parameters.AddWithValue("@dateOfBirth", customer.DateOfBirth);
                userCommand.Parameters.AddWithValue("@locationId", customer.LocationId);

                NpgsqlCommand customerCommand = new NpgsqlCommand(customerQuery, connection);
                customerCommand.Parameters.AddWithValue("@id", customer.Id);
                customerCommand.Parameters.AddWithValue("@registerDate", customer.RegisterDate);

                await connection.OpenAsync();
                NpgsqlTransaction transaction = connection.BeginTransaction();

                userCommand.Transaction = customerCommand.Transaction = transaction;

                int userResult = await userCommand.ExecuteNonQueryAsync();
                int customerResult = await customerCommand.ExecuteNonQueryAsync();
                if (userResult != 0 && customerResult != 0)
                {
                    succeded = true;
                    await transaction.CommitAsync();
                }
            }
            return succeded;
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            int numberOfAffectedRows = 0;
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand();
                List<string> updatedValues = new List<string>();
                command.Connection = connection;
                command.Parameters.AddWithValue("@id", customer.Id);

                command.CommandText = "UPDATE \"User\" SET \"FirstName\" = @firstName, \"LastName\" = @lastName, \"Email\" = @email, \"PhoneNumber\" = @phoneNumber, \"LocationId\" = @locationId WHERE \"Id\" = @id";

                command.Parameters.AddWithValue("@firstName", customer.FirstName);
                command.Parameters.AddWithValue("@lastName", customer.LastName);
                command.Parameters.AddWithValue("@email", customer.Email);
                command.Parameters.AddWithValue("@phoneNumber", customer.PhoneNumber);
                command.Parameters.AddWithValue("@locationId", customer.Location.Id);

                await connection.OpenAsync();
                numberOfAffectedRows = await command.ExecuteNonQueryAsync();
            }
            return numberOfAffectedRows != 0;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            bool succeded = false;
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                string customerQuery = "DELETE FROM \"Customer\" where \"Id\" = @id;";
                string userQuery = "DELETE FROM \"User\" where \"Id\" = @id";
                NpgsqlCommand customerCommand = new NpgsqlCommand(customerQuery, connection);
                customerCommand.Parameters.AddWithValue("@id", id);

                NpgsqlCommand userCommand = new NpgsqlCommand(userQuery, connection);
                userCommand.Parameters.AddWithValue("@id", id);

                await connection.OpenAsync();
                NpgsqlTransaction transaction = connection.BeginTransaction();

                customerCommand.Transaction = userCommand.Transaction = transaction;

                int customerResult = await customerCommand.ExecuteNonQueryAsync();
                int userResult = await userCommand.ExecuteNonQueryAsync();

                if (customerResult != 0 && userResult != 0)
                {
                    succeded = true;
                    await transaction.CommitAsync();
                }
            }
            return succeded;
        }

        private Customer ReadCustomer(NpgsqlDataReader reader)
        {
            try
            {
                return new Customer
                {
                    Id = (Guid)reader["Id"],
                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                    Email = Convert.ToString(reader["Email"]),
                    FirstName = Convert.ToString(reader["FirstName"]),
                    LastName = Convert.ToString(reader["LastName"]),
                    PhoneNumber = Convert.ToString(reader["LastName"]),
                    LocationId = (Guid)reader["LocationId"],
                    RegisterDate = Convert.ToDateTime(reader["RegisterDate"]),
                    Location = new Location
                    {
                        Id = (Guid)reader["LocationId"],
                        Address = Convert.ToString(reader["Address"]),
                        City = Convert.ToString(reader["City"]),
                        Country = Convert.ToString(reader["Country"]),
                        ZipCode = Convert.ToString(reader["ZipCode"])
                    }
                };
            }
            catch { return null; }
        }
    }
}
