using PinusPengger.Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace PinusPengger.DataAccessLayer
{
    /// <summary>
    /// This class implements the CRUD mechanism for the customer table.
    /// </summary>
    public class CustomerDAL : IRepository
    {
        /// <summary>
        /// Initializes an instance of <see cref="CustomerDAL"/>.
        /// </summary>
        public CustomerDAL()
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
            Connection.Open();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public SqlConnection Connection { get; set; }

        /// <summary>
        /// Executes commands for the methods <see cref="InsertRecord(object)"/>,
        /// <see cref="UpdateRecord(object)"/>, and <see cref="DeleteRecord(object)"/>.
        /// </summary>
        /// <param name="query">The query to be executed by the database.</param>
        /// <param name="args">The arguments required by the query.</param>
        private void ExecuteDMLCommand(string query, Dictionary<string, object> args)
        {
            SqlTransaction tran = Connection.BeginTransaction();

            try
            {
                using (var cmd = new SqlCommand(query, Connection, tran))
                {
                    foreach (var pair in args)
                    {
                        cmd.Parameters.AddWithValue(pair.Key, pair.Value);
                    }
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                }
            }
            catch (Exception)
            {
                tran.Rollback();
            }
            finally
            {
                tran.Dispose();
            }
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public List<object> ReadData()
        {
            var result = new List<Customer>();

            string query = ConfigurationManager.AppSettings["CustomerDAL:ReadData"] ?? string.Empty;

            using (var cmd = new SqlCommand(query, Connection))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var customer = new Customer
                        {
                            CustomerID = rdr.GetInt32(0),
                            FirstName = rdr.GetString(1),
                            LastName = rdr.GetString(2),
                            NIK = rdr.GetString(3),
                            PhoneNumber = rdr.GetString(4),
                            Email = rdr.GetString(5)
                        };
                        result.Add(customer);
                    }
                }
            }

            return result.Select(x => (object)x).ToList();
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="obj"><inheritdoc/></param>
        public void InsertRecord(object obj)
        {
            string query = ConfigurationManager.AppSettings["CustomerDAL:InsertRecord"] ?? string.Empty;

            if (obj is Customer customer)
            {
                var args = new Dictionary<string, object>
                {
                    {"@firstName", customer.FirstName },
                    {"@lastName", customer.LastName },
                    {"@nik", customer.NIK },
                    {"@phoneNumber", customer.PhoneNumber },
                    {"@email", customer.Email }

                };
                ExecuteDMLCommand(query, args);
            }
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="obj"><inheritdoc/></param>
        /// <exception cref="NotImplementedException"></exception>
        public void UpdateRecord(object obj)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="obj"><inheritdoc/></param>
        /// <exception cref="NotImplementedException"></exception>
        public void DeleteRecord(object obj)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Connection.Close();
            Connection.Dispose();
        }
    }
}
