using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SQLWithCSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            var customers = new List<Customer>();

            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();

                using (var updateCustomerCommand = new SqlCommand("UpdateCustomer", connection))
                {
                    updateCustomerCommand.CommandType = CommandType.StoredProcedure;

                    updateCustomerCommand.Parameters.AddWithValue("ID", "STAR");
                    updateCustomerCommand.Parameters.AddWithValue("NewName", "Ensin Snow");

                    int affected = updateCustomerCommand.ExecuteNonQuery();

                };

                //Console.WriteLine(connection.State);


                //    // UPDATE
                //string sqlUpdateString = $"UPDATE Customers SET City = 'Barcelona' WHERE CustomerID = 'STAR'";

                //using (var command3 = new SqlCommand(sqlUpdateString, connection))
                //{
                //    int affected = command3.ExecuteNonQuery();
                //}


                //    // DELETE   
                //string sqlDeleteString = $"DELETE FROM Customers WHERE CustomerID = 'STAR'";

                //using (var command4 = new SqlCommand(sqlDeleteString, connection))
                //{
                //    int affected = command4.ExecuteNonQuery();
                //}


            }

                //    // CREATE
                //    var newCustomer = new Customer()
                //    {
                //        CustomerID = "STAR",
                //        ContactName = "Ensign Snow",
                //        City = "New London",
                //        CompanyName = "STAR_FLEET"
                //    };

                //    string sqlString = $"INSERT INTO Customers(CustomerID, ContactName, City, CompanyName) VALUES('{newCustomer.CustomerID}','{newCustomer.ContactName}','{newCustomer.City}', '{newCustomer.CompanyName}')";


                //    using (var command2 = new SqlCommand(sqlString, connection))
                //    {
                //        int affected = command2.ExecuteNonQuery();
                //    }
                //}

                // READ 
                //using (var command = new SqlCommand("SELECT * FROM Customers", connection))
                //{
                //    SqlDataReader sqlReader = command.ExecuteReader();

                //    while (sqlReader.Read()) 
                //    {
                //        var customerID = sqlReader["CustomerID"].ToString();
                //        var contactName = sqlReader["ContactName"].ToString();
                //        var companyName = sqlReader["CompanyName"].ToString();
                //        var city = sqlReader["City"].ToString();
                //        var contactTitle = sqlReader["ContactTitle"].ToString();


                //        var customer = new Customer() 
                //        {
                //            ContactTitle = contactTitle,
                //            CustomerID = customerID,
                //            ContactName = contactName,
                //            CompanyName = companyName,
                //            City = city

                //        };
                //        customers.Add(customer);

                //    }
                //    foreach (var c in customers) 
                //    {
                //        Console.WriteLine($"Customer {c.GetFullName()} has ID {c.CustomerID} and lives in {c.City}");
                //    }




            }

        public class Customer
        {
            public string CustomerID { get; set; }
            public string CompanyName { get; set; }
            public string ContactName { get; set; }
            public string ContactTitle { get; set; }
            public string City { get; set; }


            public string GetFullName()
            {
                return $"{ContactTitle} - {ContactName}";
            }
        }



    }

}
