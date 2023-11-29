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
                        connection.Execute("DELETE FROM Product WHERE Id = @Id", new { Id });
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

        public async Task<List<ProductModel>> GetAll()
        {
            var listProduct = new List<ProductModel>();

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                listProduct = connection.Query<ProductModel>(@"SELECT Id, Name, Price FROM Product").ToList();
                connection.Close();
            }

            return listProduct;
        }

        public async Task<(bool, string)> Save(ProductModel Product)
        {
            try
            {
                using (var connection = new SqlConnection(connString))
                {
                    connection.Open();
                    try
                    {
                        connection.Execute("INSERT INTO Product(Name, Price) VALUES " +
                            "(@Name, @Price) ",
                            new
                            {
                                Product.Name,
                                Product.Price
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

        public async Task<bool> Update(ProductModel Product)
        {
            try
            {
                using (var connection = new SqlConnection(connString))
                {
                    connection.Open();
                    try
                    {
                        connection.Execute("UPDATE Product SET Name = @Name, " +
                            "Price = @Price " +
                        "WHERE Id = @Id ",
                        new
                        {
                            Product.Id,
                            Product.Name,
                            Product.Price
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
