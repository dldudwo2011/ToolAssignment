using Assignment5.Models;
using Microsoft.Data.SqlClient;
using System.Data;


namespace Assignment5.TechnicalServices
{
    public class Customers
    {
        public List<Customer> GetCustomers()
        {
            SqlConnection DataSource = new ();

            DataSource.ConnectionString = @"Persist Security Info=False;
                            Initial Catalog=NorthWind;
                            User ID=ylee39;
                            Password=Zheldcjswo8fd87559;
                            Server=dev1.baist.ca;";

            DataSource.Open();

            SqlCommand GetCustomersCommand = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "ylee39.GetNorthwindCustomers"
            };
            SqlDataReader CustomerDataReader = GetCustomersCommand.ExecuteReader();

            List<Customer> CustomerList = new();

            if (CustomerDataReader.HasRows)
            {
                while (CustomerDataReader.Read())
                {
                    Customer customer = new()
                    {
                        // see tabke definition for columns
                        CustomerID = (string)CustomerDataReader["CustomerID"],
                        CompanyName = (string)CustomerDataReader["CompanyName"],
                        ContactName = CustomerDataReader["ContactName"] == DBNull.Value ? null : (string)CustomerDataReader["ContactName"],
                        ContactTitle = CustomerDataReader["ContactTitle"] == DBNull.Value ? null : (string)CustomerDataReader["ContactTitle"],
                        Address = CustomerDataReader["Address"] == DBNull.Value ? null : (string)CustomerDataReader["Address"],
                        City = CustomerDataReader["City"] == DBNull.Value ? null : (string)CustomerDataReader["City"],
                        Region = CustomerDataReader["Region"] == DBNull.Value ? null : (string)CustomerDataReader["Region"],
                        PostalCode = CustomerDataReader["PostalCode"] == DBNull.Value ? null : (string)CustomerDataReader["PostalCode"],
                        Country = CustomerDataReader["Country"] == DBNull.Value ? null : (string)CustomerDataReader["Country"],
                        Phone = CustomerDataReader["Phone"] == DBNull.Value ? null : (string)CustomerDataReader["Phone"],
                        Fax = CustomerDataReader["Fax"] == DBNull.Value ? null : (string)CustomerDataReader["Fax"]
                    };
                    CustomerList.Add(customer);
                }
            }

            CustomerDataReader.Close();
            DataSource.Close();
            return CustomerList;
        }


        public Customer GetCustomer(string customerID)
        {
            SqlConnection DataSource = new();
            DataSource.ConnectionString = @"Persist Security Info=False;
                            Initial Catalog=NorthWind;
                            User ID=ylee39;
                            Password=Zheldcjswo8fd87559;
                            Server=dev1.baist.ca;";
            DataSource.Open();
            SqlCommand GetCustomerCommand = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "ylee39.GetNorthwindCustomer"
            };
            SqlParameter GetItemCommandParameter = new()
            {
                ParameterName = "@CustomerID",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                SqlValue = customerID
            };
            GetCustomerCommand.Parameters.Add(GetItemCommandParameter);
            SqlDataReader CustomerDataReader = GetCustomerCommand.ExecuteReader();
            Customer customer = new();
            if (CustomerDataReader.HasRows)
            {
                CustomerDataReader.Read();

                customer.CustomerID = (string)CustomerDataReader["CustomerID"];
                customer.CompanyName = (string)CustomerDataReader["CompanyName"];
                customer.ContactName = CustomerDataReader["ContactName"] == DBNull.Value ? null : (string)CustomerDataReader["ContactName"];
                customer.ContactTitle = CustomerDataReader["ContactTitle"] == DBNull.Value ? null : (string)CustomerDataReader["ContactTitle"];
                customer.Address = CustomerDataReader["Address"] == DBNull.Value ? null : (string)CustomerDataReader["Address"];
                customer.City = CustomerDataReader["City"] == DBNull.Value ? null : (string)CustomerDataReader["City"];
                customer.Region = CustomerDataReader["Region"] == DBNull.Value ? null : (string)CustomerDataReader["Region"];
                customer.PostalCode = CustomerDataReader["PostalCode"] == DBNull.Value ? null : (string)CustomerDataReader["PostalCode"];
                customer.Country = CustomerDataReader["Country"] == DBNull.Value ? null : (string)CustomerDataReader["Country"];
                customer.Phone = CustomerDataReader["Phone"] == DBNull.Value ? null : (string)CustomerDataReader["Phone"];
                customer.Fax = CustomerDataReader["Fax"] == DBNull.Value ? null : (string)CustomerDataReader["Fax"];

            }
            CustomerDataReader.Close();
            DataSource.Close();
            return customer;
        }


    }
}
