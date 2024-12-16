using System;
using System.Data;
using Microsoft.Data.SqlClient;
using ABCHardware_YoungjaeLee.Domain;

namespace ABCHardware_YoungjaeLee.TechnicalServices
{
    public class Items
    {
        private readonly string _connectionString;

        public Items()
        {
            // Manually load configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Set the base path
                .AddJsonFile("appsettings.json") // Add the appsettings.json file
                .Build(); // Build the configuration

            // Get the connection string from the configuration
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Add a new item
        public bool AddItem(Item newItem)
        {
            bool success = false;
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = new()
            {
                Connection = connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddItem"
            };

            command.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar) { Value = newItem.Description });
            command.Parameters.Add(new SqlParameter("@UnitPrice", SqlDbType.Decimal) { Value = newItem.UnitPrice });
            command.Parameters.Add(new SqlParameter("@QuantityOnHand", SqlDbType.Int) { Value = newItem.QuantityOnHand });

            command.ExecuteNonQuery();
            connection.Close();
            success = true;

            return success;
        }

        // Update item information
        public bool UpdateItem(Item updatedItem)
        {
            bool success = false;
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = new()
            {
                Connection = connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "UpdateItem"
            };

            command.Parameters.Add(new SqlParameter("@ItemCode", SqlDbType.VarChar) { Value = updatedItem.ItemCode });
            command.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar) { Value = updatedItem.Description });
            command.Parameters.Add(new SqlParameter("@UnitPrice", SqlDbType.Decimal) { Value = updatedItem.UnitPrice });
            command.Parameters.Add(new SqlParameter("@QuantityOnHand", SqlDbType.Int) { Value = updatedItem.QuantityOnHand });

            command.ExecuteNonQuery();
            connection.Close();
            success = true;

            return success;
        }

        // Delete an item by ItemCode
        public bool DeleteItem(string itemCode)
        {
            bool success = false;
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = new()
            {
                Connection = connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "DeleteItem"
            };

            command.Parameters.Add(new SqlParameter("@ItemCode", SqlDbType.VarChar) { Value = itemCode });

            command.ExecuteNonQuery();
            connection.Close();
            success = true;

            return success;
        }

        // Get all items
        public List<Item> GetItems()
        {
            List<Item> items = new();

            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = new()
            {
                Connection = connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetItems"
            };

            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                items.Add(new Item
                {
                    ItemCode = reader["ItemCode"].ToString(),
                    Description = reader["Description"].ToString(),
                    UnitPrice = reader["UnitPrice"] != DBNull.Value ? Convert.ToDecimal(reader["UnitPrice"]) : 0,
                    QuantityOnHand = reader["QuantityOnHand"] != DBNull.Value ? Convert.ToInt32(reader["QuantityOnHand"]) : 0
                });
            }

            connection.Close();

            return items;
        }
    }
}
