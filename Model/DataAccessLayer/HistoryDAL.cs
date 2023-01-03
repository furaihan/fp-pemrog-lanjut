using System.Configuration;
using System.Data.SqlClient;
using TestingDatabase.Model.EntityModel;

namespace TestingDatabase.Model.DataAccessLayer
{
    internal class HistoryDAL : IRepository, IDisposable
    {

        public HistoryDAL()
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
            var result = new List<History>();

            string query = ConfigurationManager.AppSettings["HistoryDAL:ReadData"] ?? string.Empty;

            using (var cmd = new SqlCommand(query, Connection))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var history = new History()
                        {
                            HistoryID = rdr.GetInt32(0),
                            ReservationCode = rdr.GetString(1),
                            NumberOfGuests = rdr.GetByte(2),
                            Checkin = rdr.GetDateTime(3),
                            Checkout = rdr.GetDateTime(4),
                            CustomerID = rdr.GetInt32(5),
                            RoomID = rdr.GetInt32(6)
                        };
                        result.Add(history);
                    }
                }
            }

            return result.Select(x => (object)x).ToList();
        }

        public void InsertRecord(object obj)
        {
            string query = ConfigurationManager.AppSettings["HistoryDAL:InsertRecord"] ?? string.Empty;

            if (obj is History history)
            {
                var args = new Dictionary<string, object>
                {
                    {"@reservationCode", history.ReservationCode },
                    {"@numberOfGuests", history.NumberOfGuests },
                    {"@checkin", history.Checkin },
                    {"@checkout", history.Checkout },
                    {"@customerID", history.CustomerID },
                    {"@roomID", history.RoomID }
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
