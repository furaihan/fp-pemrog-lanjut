using System.Configuration;
using System.Data.SqlClient;
using TestingDatabase.Model.EntityModel;

namespace TestingDatabase.Model.DataAccessLayer
{
    internal class CustomerDAL : IRepository, IDisposable
    {
        public CustomerDAL()
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
            Connection.Open();
        }

        public SqlConnection Connection { get; set; }

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

        public void UpdateRecord(object obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecord(object obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Connection.Close();
            Connection.Dispose();
        }
    }
}
