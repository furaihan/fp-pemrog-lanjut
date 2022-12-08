using PinusPengger.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PinusPengger.Repository
{
    internal class HistoryCRUD : DatabaseCRUD<History>
    {
        public override void DeleteRecord(History history)
        {
            const string query = "DELETE FROM riwayat WHERE id = @id";

            var args = new Dictionary<string, object>
            {
                {"@id", history.HisID},
            };

            ExecuteWrite(query, args);
        }

        public override void InsertRecord(History history)
        {
            const string query = "INSERT INTO riwayat(kode_reservasi, checkin, checkout, pelanggan, kamar) VALUES(@kodeReservasi, @checkin, @checkout, @pelanggan, @kamar)";

            var args = new Dictionary<string, object>
            {
                {"@kodeReservasi", history.ResCode },
                {"@checkin", history.ResCheckIn },
                {"@checkout", history.ResCheckOut },
                {"@pelanggan", history.ResIDCust },
                {"@kamar", history.ResIDRoom },
            };

            ExecuteWrite(query, args);
        }

        public override List<History> ReadData()
        {
            var result = new List<History>();

            const string query = "SELECT * FROM riwayat";

            SqlDataReader rdr = ExecuteRead(query);

            while (rdr.Read())
            {
                var history = new History()
                {
                    HisID = Convert.ToInt32(rdr["id"]),
                    ResCode = rdr["kode_reservasi"].ToString(),
                    ResCheckIn = Convert.ToDateTime(rdr["checkin"]),
                    ResCheckOut = Convert.ToDateTime(rdr["checkout"]),
                    ResIDCust = Convert.ToInt32(rdr["pelanggan"]),
                    ResIDRoom = Convert.ToInt32(rdr["kamar"])
                };
                result.Add(history);
            }

            return result;
        }

        public override void UpdateRecord(History history)
        {
            const string query = "UPDATE riwayat SET kode_reservasi = @kodeReservasi, checkin = @checkin, checkout = @checkout, pelanggan = @pelanggan, kamar = @kamar WHERE id = @id";

            var args = new Dictionary<string, object>
            {
                {"@kodeReservasi", history.ResCode },
                {"@checkin", history.ResCheckIn },
                {"@checkout", history.ResCheckOut },
                {"@pelanggan", history.ResIDCust },
                {"@kamar", history.ResIDRoom }
            };

            ExecuteWrite(query, args);
        }
    }
}
