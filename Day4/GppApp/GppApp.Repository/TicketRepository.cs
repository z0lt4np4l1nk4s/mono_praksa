using GppApp.Common;
using GppApp.Common.Filters;
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
    public class TicketRepository : ITicketRepository
    {
        public string ConnectionString { get => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }

        public async Task<PagedList<Ticket>> GetAll(Sorting sorting, Paging paging, TicketFilter ticketFilter)
        {
            PagedList<Ticket> pagedList = new PagedList<Ticket>();
            if (sorting == null) sorting = new Sorting();
            if (paging == null) paging = new Paging();

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = connection;
                command.Parameters.AddWithValue("@pageSize", paging.PageSize);
                command.Parameters.AddWithValue("@skip", (paging.CurrentPage - 1) * paging.PageSize);

                List<string> parameters = new List<string>();

                if (ticketFilter != null)
                {
                    if (ticketFilter.MinPrice != null)
                    {
                        parameters.Add("\"Price\" >= @minPrice");
                        command.Parameters.AddWithValue("@minPrice", ticketFilter.MinPrice);
                    }

                    if (ticketFilter.MaxPrice != null)
                    {
                        parameters.Add("\"Price\" <= @maxPrice");
                        command.Parameters.AddWithValue("@maxPrice", ticketFilter.MaxPrice);
                    }

                    if (ticketFilter.ZoneTypes != null)
                    {
                        parameters.Add($"\"ZoneTypeId\" in ({string.Join(",", ticketFilter.ZoneTypes.Select(x => "'" + x + "'"))})");
                        //command.Parameters.AddWithValue("@zoneType", ticketFilter.ZoneTypes);
                    }

                    if (ticketFilter.TicketTypes != null)
                    {
                        parameters.Add($"\"TicketTypeId\" in ({string.Join(",", ticketFilter.TicketTypes.Select(x => "'" + x + "'"))})");
                        //command.Parameters.AddWithValue("@ticketType", string.Join(",", ticketFilter.TicketTypes.Select(x => "'" + x + "'")));
                    }
                }

                string selectQuery = "SELECT t.*, zt.\"Name\" as \"ZoneName\", tt.\"Name\" as \"TicketName\" FROM \"Ticket\" t INNER JOIN \"ZoneType\" zt ON t.\"ZoneTypeId\" = zt.\"Id\" INNER JOIN \"TicketType\" tt ON t.\"TicketTypeId\" = tt.\"Id\" " +
                    (parameters.Count == 0 ? "" : "WHERE " + string.Join(" and ", parameters)) +
                    $" ORDER BY \"{sorting.SortBy}\" {(sorting.SortOrder.ToLower() == "asc" ? "ASC" : "DESC")} LIMIT @pageSize OFFSET @skip;";

                command.CommandText = selectQuery;

                string countQuery = "SELECT COUNT(*) FROM \"Ticket\"" + (parameters.Count == 0 ? "" : " WHERE " + string.Join(" and ", parameters));

                NpgsqlCommand countCommand = new NpgsqlCommand(countQuery, connection);

                await connection.OpenAsync();

                object countResult = await countCommand.ExecuteScalarAsync();

                NpgsqlDataReader reader = await command.ExecuteReaderAsync();

                if (countResult == null || !reader.HasRows) return null;

                while (reader.HasRows && await reader.ReadAsync())
                {
                    pagedList.Data.Add(ReadTicket(reader));
                }

                pagedList.PageSize = paging.PageSize;
                pagedList.CurrentPage = paging.CurrentPage;
                pagedList.ItemCount = Convert.ToInt32(countResult);
                pagedList.LastPage = Convert.ToInt32(pagedList.ItemCount / paging.PageSize) + (pagedList.ItemCount % paging.PageSize != 0 ? 1 : 0);
            }

            return pagedList;
        }

        private Ticket ReadTicket(NpgsqlDataReader reader)
        {
            try
            {
                return new Ticket
                {
                    Id = (Guid)reader["Id"],
                    Price = Convert.ToDouble(reader["Price"]),
                    TicketTypeId = (Guid)reader["TicketTypeId"],
                    TicketType = new TicketType 
                    { 
                        Id = (Guid)reader["TicketTypeId"],
                        Name = Convert.ToString(reader["ZoneName"])},
                    ZoneTypeId = (Guid)reader["ZoneTypeId"],
                    ZoneType = new ZoneType
                    {
                        Id = (Guid)reader["ZoneTypeId"],
                        Name = Convert.ToString(reader["ZoneName"])
                    }
                };
            }
            catch { return null; }
        }
    }
}
