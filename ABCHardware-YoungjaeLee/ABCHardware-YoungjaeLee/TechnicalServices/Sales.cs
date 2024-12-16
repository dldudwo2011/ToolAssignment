using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using ABCHardware_YoungjaeLee.Domain;

namespace ABCHardware_YoungjaeLee.TechnicalServices
{
    public class Sales
    {
        private readonly string _connectionString;

        public Sales()
        {
            // Manually load configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Set the base path
                .AddJsonFile("appsettings.json") // Add the appsettings.json file
                .Build(); // Build the configuration

            // Get the connection string from the configuration
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public int AddSale(Sale ABCSale)
        {
            // Validate the ABCSale object
            if (ABCSale == null || ABCSale.SalesItems == null || ABCSale.SalesItems.Count == 0)
            {
                throw new ArgumentException("Invalid sale data provided.");
            }

            int saleNumber = -1;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Serialize SalesItems to JSON
                var salesItemsJson = JsonSerializer.Serialize(ABCSale.SalesItems);

                // Insert the sale into the database
                using (var command = new SqlCommand("AddSale", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@SaleDate", ABCSale.SaleDate);
                    command.Parameters.AddWithValue("@SalespersonID", ABCSale.SalespersonID);
                    command.Parameters.AddWithValue("@CustomerID", ABCSale.CustomerID);
                    command.Parameters.AddWithValue("@SubTotal", ABCSale.SubTotal);
                    command.Parameters.AddWithValue("@GST", ABCSale.GST);
                    command.Parameters.AddWithValue("@SaleTotal", ABCSale.SaleTotal);
                    command.Parameters.AddWithValue("@SalesItems", salesItemsJson);

                    // Handle return value
                    var returnParameter = new SqlParameter
                    {
                        ParameterName = "@ReturnCode",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.ReturnValue
                    };
                    command.Parameters.Add(returnParameter);

                    // Execute the command
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        saleNumber = Convert.ToInt32(result);
                    }

                    int returnCode = Convert.ToInt32(returnParameter.Value);

                    // Check return code
                    if (returnCode != 0)
                    {
                        throw new Exception("Failed to add sale. Return code: " + returnCode);
                    }
                }
            }

            return saleNumber; // Return the SaleNumber
        }

    }
}
