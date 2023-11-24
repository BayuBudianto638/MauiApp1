using Dapper;
using MauiApp1.Models;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace MauiApp1.Applications.Customers
{
    internal class CustomerAppService : ICustomerAppService
    {
        private readonly string connString = @"Server=FAIRUZ-PC\SQLEXPRESS;Database=TEST;Trusted_Connection=True;TrustServerCertificate=True;";

        public bool Delete(int Id)
        {
            try
            {
                using (var connection = new SqlConnection(connString))
                {
                    connection.Open();
                    try
                    {
                        connection.Execute("DELETE FROM Customer WHERE CustomerId = @Id", new { Id });
                    }
                    catch (DbException dbex)
                    {
                    }
                }
                return true;
            }
            catch (DbException db)
            {
                return false;
            }
        }

        public (bool, string) Save(Customer customer)
        {
            try
            {
                using (var connection = new SqlConnection(connString))
                {
                    connection.Open();
                    try
                    {
                        connection.Execute("INSERT INTO Customer(Name) VALUES " +
                            "(@Name) ",
                            new
                            {
                                customer.Name
                            });

                    }
                    catch (DbException dbex)
                    {

                    }
                    connection.Close();
                }

                return (true, "SUKSES");
            }
            catch (DbException db)
            {
                return (false, "GAGAL");
            }
        }

        public bool Update(Customer customer)
        {
            try
            {
                using (var connection = new SqlConnection(connString))
                {
                    connection.Open();
                    try
                    {
                        connection.Execute("UPDATE Customer SET CustomerName = @CustomerName " +
                        "WHERE CustomerId = @CustomerId ",
                        new
                        {
                            customer.Id,
                            customer.Name
                        });
                    }
                    catch (DbException dbex)
                    {
                    }
                    connection.Close();
                }

                return true;
            }
            catch (DbException db)
            {
                return false;
            }
        }
    }
}
