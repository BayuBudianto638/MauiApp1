using Dapper;
using MauiApp1.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Applications.Products
{
    internal class ProductAppService : IProductAppService
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
                        connection.Execute("DELETE FROM Product WHERE ProductId = @Id", new { Id });
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

        public async Task<List<Product>> GetAll()
        {
            var listProduct = new List<Product>();

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                listProduct = connection.Query<Product>(@"SELECT Id, Name FROM Product").ToList();
                connection.Close();
            }

            return listProduct;
        }

        public async Task<(bool, string)> Save(Product Product)
        {
            try
            {
                using (var connection = new SqlConnection(connString))
                {
                    connection.Open();
                    try
                    {
                        connection.Execute("INSERT INTO Product(Name) VALUES " +
                            "(@Name) ",
                            new
                            {
                                Product.Name
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

        public async Task<bool> Update(Product Product)
        {
            try
            {
                using (var connection = new SqlConnection(connString))
                {
                    connection.Open();
                    try
                    {
                        connection.Execute("UPDATE Product SET ProductName = @ProductName " +
                        "WHERE ProductId = @ProductId ",
                        new
                        {
                            Product.Id,
                            Product.Name
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
