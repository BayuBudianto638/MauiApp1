using Dapper;
using MauiApp1.Models;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace MauiApp1.Applications.Customers
{
    internal class CustomerAppService : ICustomerAppService
    {
        private readonly string connString = @"Server=FAIRUZ-PC\SQLEXPRESS;Database=TEST;Trusted_Connection=True;TrustServerCertificate=True;";

        public async Task<bool> Delete(int Id)
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
                return await Task.Run(() => true);
            }
            catch (DbException db)
            {
                return await Task.Run(() => false);
            }
        }

        public async Task<(bool, string)> Save(Customer customer)
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

                return await Task.Run(() => (true, "SUKSES"));
            }
            catch (DbException db)
            {
                return await Task.Run(() => (false, "GAGAL"));
            }
        }

        public async Task<bool> Update(Customer customer)
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

                return await Task.Run(() => true);
            }
            catch (DbException db)
            {
                return await Task.Run(() => false);
            }
        }
    }
}
