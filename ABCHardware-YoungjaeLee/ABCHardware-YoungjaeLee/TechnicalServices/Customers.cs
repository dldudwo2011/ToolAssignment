
using System.Data;
using Microsoft.Data.SqlClient;
using ABCHardware_YoungjaeLee.Domain;

namespace ABCHardware_YoungjaeLee.TechnicalServices
{
    public class Customers
    {
        private readonly string _connectionString;

        public Customers()
        {
            // Manually load configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Set the base path
                .AddJsonFile("appsettings.json") // Add the appsettings.json file
                .Build(); // Build the configuration

            // Get the connection string from the configuration
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Add a new customer
        public bool AddCustomer(Customer newCustomer)
        {
            bool success = false;
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = new()
            {
                Connection = connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddCustomer"
            };

            command.Parameters.Add(new SqlParameter("@CustomerName", SqlDbType.VarChar) { Value = newCustomer.CustomerName });
            command.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar) { Value = newCustomer.Address });
            command.Parameters.Add(new SqlParameter("@City", SqlDbType.VarChar) { Value = newCustomer.City });
            command.Parameters.Add(new SqlParameter("@Province", SqlDbType.VarChar) { Value = newCustomer.Province });
            command.Parameters.Add(new SqlParameter("@PostalCode", SqlDbType.VarChar) { Value = newCustomer.PostalCode });

            command.ExecuteNonQuery();
            connection.Close();
            success = true;

            return success;
        }

        // Update customer information
        public bool UpdateCustomer(Customer updatedCustomer)
        {
            bool success = false;
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = new()
            {
                Connection = connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "UpdateCustomer"
            };

            command.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int) { Value = updatedCustomer.CustomerID });
            command.Parameters.Add(new SqlParameter("@CustomerName", SqlDbType.VarChar) { Value = updatedCustomer.CustomerName });
            command.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar) { Value = updatedCustomer.Address });
            command.Parameters.Add(new SqlParameter("@City", SqlDbType.VarChar) { Value = updatedCustomer.City });
            command.Parameters.Add(new SqlParameter("@Province", SqlDbType.VarChar) { Value = updatedCustomer.Province });
            command.Parameters.Add(new SqlParameter("@PostalCode", SqlDbType.VarChar) { Value = updatedCustomer.PostalCode });

            command.ExecuteNonQuery();
            connection.Close();
            success = true;

            return success;
        }

        // Delete a customer by ID
        public bool DeleteCustomer(int customerID)
        {
            bool success = false;
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = new()
            {
                Connection = connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "DeleteCustomer"
            };

            command.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int) { Value = customerID });

            command.ExecuteNonQuery();
            connection.Close();
            success = true;

            return success;
        }
    }
}
