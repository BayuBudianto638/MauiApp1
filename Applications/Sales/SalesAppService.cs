using Dapper;
using MauiApp1.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Applications.Sales
{
    internal class SalesAppService : ISalesAppService
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
                        connection.Execute("DELETE FROM SalesHeader WHERE SalesHeaderId = @Id", new { Id });
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

        public async Task<List<SalesHeader>> GetAll()
        {
            var listSalesHeader = new List<SalesHeader>();

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                listSalesHeader = connection.Query<SalesHeader>(@"SELECT Id, Name FROM SalesHeader").ToList();
                connection.Close();
            }

            return listSalesHeader;
        }

        public async Task<(bool, string)> Save(SalesHeader SalesHeader)
        {
            try
            {
                using (var connection = new SqlConnection(connString))
                {
                    connection.Open();
                    try
                    {
                        connection.Execute("INSERT INTO SalesHeader(Name) VALUES " +
                            "(@Name) ",
                            new
                            {
                                SalesHeader.Code
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

        public async Task<bool> Update(SalesHeader SalesHeader)
        {
            try
            {
                using (var connection = new SqlConnection(connString))
                {
                    connection.Open();
                    try
                    {
                        connection.Execute("UPDATE SalesHeader SET SalesHeaderName = @SalesHeaderName " +
                        "WHERE SalesHeaderId = @SalesHeaderId ",
                        new
                        {
                            SalesHeader.Id,
                            SalesHeader.Code
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
