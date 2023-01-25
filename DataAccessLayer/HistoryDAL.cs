using PinusPengger.Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace PinusPengger.DataAccessLayer
{
    /// <summary>
    /// Mekanisme CRUD untuk tabel riwayat
    /// </summary>
    public class HistoryDAL : IRepository
    {
        private void Connect(ConnectionStringSettingsCollection settingsCollection, int index)
        {
            try
            {
                Connection = new SqlConnection(settingsCollection[index].ConnectionString);
                Connection.Open();
            }
            catch (Exception)
            {
                Connect(settingsCollection, index + 1);
            }
        }
        /// <summary>
        /// Menginisialisasi objek <see cref="HistoryDAL"/>
        /// </summary>
        public HistoryDAL()
        {
            Connect(ConfigurationManager.ConnectionStrings, 0);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public SqlConnection Connection { get; set; }

        /// <summary>
        /// Mengeksekusi perintah untuk method <see cref="InsertRecord(object)"/>,
        /// <see cref="UpdateRecord(object)"/>, dan <see cref="DeleteRecord(object)"/>
        /// </summary>
        /// <param name="query">Kueri yang akan dieksekusi oleh database</param>
        /// <param name="args">Argumen yang dibutuhkan oleh kueri</param>
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
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="obj"><inheritdoc/></param>
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
