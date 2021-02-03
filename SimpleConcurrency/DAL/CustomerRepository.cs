using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SimpleConcurrency.Models;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace SimpleConcurrency.DAL
{
    public class CustomerRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

        public Customer GetById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Customer WHERE Id = @Id";
                return conn.QuerySingleOrDefault<Customer>(sql, new { id });
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using(var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var sql = "UPDATE [dbo].[Customer] " +
                            "SET [FirstName] = @FirstName " +
                            ",[LastName] = @LastName " +
                            ",[Phone] = @Phone " +
                            ",[Email] = @Email " +
                            ",[Birthday] = @Birthday " +
                            "WHERE Id = @Id AND RowVer = @RowVer";
                        var result = conn.Execute(sql, customer, transaction: transaction);
                        transaction.Commit();
                        if (result == 0)
                        {
                            throw new DBConcurrencyException("There has been changes to the customer, please try again");
                        }
                    }
                    catch (Exception e)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}
