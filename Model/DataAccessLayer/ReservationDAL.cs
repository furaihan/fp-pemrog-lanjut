using System.Configuration;
using System.Data.SqlClient;
using TestingDatabase.Model.EntityModel;

namespace TestingDatabase.Model.DataAccessLayer
{
    internal class ReservationDAL : IRepository, IDisposable
    {

        public ReservationDAL()
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
            var result = new List<Reservation>();

            string query = ConfigurationManager.AppSettings["ReservationDAL:ReadData"] ?? string.Empty;

            using (var cmd = new SqlCommand(query, Connection))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var reservation = new Reservation

                        {
                            ReservationID = rdr.GetInt32(0),
                            ReservationCode = rdr.GetString(1),
                            NumberOfGuests = rdr.GetByte(2),
                            Checkin = rdr.GetDateTime(3),
                            Checkout = rdr.GetDateTime(4),
                            ReservationStatus = (Tag.ReservationStatus)Enum.Parse(typeof(Tag.ReservationStatus), rdr.GetString(5)),
                            CustomerID = rdr.GetInt32(6),
                            RoomID = rdr.GetInt32(7)
                        };
                        result.Add(reservation);
                    }
                }
            }

            return result.Select(x => (object)x).ToList();
        }

        public void InsertRecord(object obj)
        {
            string query = ConfigurationManager.AppSettings["ReservationDAL:InsertRecord"] ?? string.Empty;

            if (obj is Reservation reservation)
            {
                var args = new Dictionary<string, object>
                {
                    {"@reservationCode", reservation.ReservationCode },
                    {"@numberOfGuests", reservation.NumberOfGuests },
                    {"@checkin", reservation.Checkin },
                    {"@checkout", reservation.Checkout },
                    {"@reservationStatus", reservation.ReservationStatus.ToString() },
                    {"@customerID", reservation.CustomerID },
                    {"@roomID", reservation.RoomID }
                };
                ExecuteDMLCommand(query, args);
            }
        }

        public void UpdateRecord(object obj)
        {
            string query = ConfigurationManager.AppSettings["ReservationDAL:UpdateRecord"] ?? string.Empty;

            if (obj is Reservation reservation)
            {
                var args = new Dictionary<string, object>
                {
                    {"@reservationID", reservation.ReservationID },
                    {"@reservationCode", reservation.ReservationCode },
                    {"@numberOfGuests", reservation.NumberOfGuests },
                    {"@checkin", reservation.Checkin },
                    {"@checkout", reservation.Checkout },
                    {"@reservationStatus", reservation.ReservationStatus.ToString() },
                    {"@customerID", reservation.CustomerID },
                    {"@roomID", reservation.RoomID }
                };
                ExecuteDMLCommand(query, args);
            }
        }

        public void DeleteRecord(object obj)
        {
            string query = ConfigurationManager.AppSettings["ReservationDAL:DeleteRecord"] ?? string.Empty;

            if (obj is Reservation reservation)
            {
                var args = new Dictionary<string, object>
                {
                    {"@reservationID", reservation.ReservationID }
                };
                ExecuteDMLCommand(query, args);
            }
        }

        public void Dispose()
        {
            Connection.Close();
            Connection.Dispose();
        }
    }
}
