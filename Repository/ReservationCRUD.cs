using PinusPengger.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace PinusPengger.Repository
{
    internal class ReservationCRUD : DatabaseCRUD<Reservation>
    {
        public override void DeleteRecord(Reservation reservation)
        {
            const string query = "DELETE FROM reservasi WHERE id = @id";

            var args = new Dictionary<string, object>
            {
                {"@id", reservation.ResID }
            };

            ExecuteWrite(query, args);
        }

        public override void InsertRecord(Reservation reservation)
        {
            const string query = "INSERT INTO reservasi(kode_reservasi, checkin, checkout, status_reservasi, pelanggan, kamar) VALUES(@kodeReservasi, @checkin, @checkout, @statusReservasi, @id_pelanggan, @id_kamar)";

            var args = new Dictionary<string, object>
            {
                {"@kodeReservasi", reservation.ResCode },
                {"@checkin", reservation.ResCheckIn },
                {"@checkout", reservation.ResCheckOut },
                {"@statusReservasi", reservation.ResStatus.ToString() },
                {"@id_pelanggan", reservation.ResIDCust },
                {"@id_kamar", reservation.ResIDRoom }
            };

            ExecuteWrite(query, args);
        }

        public override ObservableCollection<Reservation> ReadData()
        {
            var result = new List<Reservation>();

            const string query = "SELECT * FROM reservasi";

            SqlDataReader rdr = ExecuteRead(query);

            while (rdr.Read())
            {
                var reservation = new Reservation
                {
                    ResID = Convert.ToInt32(rdr["id"]),
                    ResCode = rdr["kode_reservasi"].ToString(),
                    ResCheckIn = Convert.ToDateTime(rdr["checkin"]),
                    ResCheckOut = Convert.ToDateTime(rdr["checkout"]),
                    ResStatus = (ReservationStatus)rdr["status_reservasi"],
                    ResIDCust = Convert.ToInt32(rdr["pelanggan"]),
                    ResIDRoom = Convert.ToInt32(rdr["kamar"])
                };
                result.Add(reservation);
            }

            var oc = new ObservableCollection<Reservation>();
            result.ForEach(x => oc.Add(x));

            return oc;
        }

        public override void UpdateRecord(Reservation reservation)
        {
            const string query = "UPDATE reservasi SET kode_reservasi = @kodeReservasi, checkin = @checkin, checkout = @checkout, status_reservasi = @statusReservasi, pelanggan = @id_pelanggan, kamar = @id_kamar WHERE id = @id";

            var args = new Dictionary<string, object>
            {
                {"@id", reservation.ResID },
                {"@kodePemesanan", reservation.ResCode },
                {"@checkin", reservation.ResCheckIn },
                {"@checkout", reservation.ResCheckOut },
                {"@statusPemesanan", reservation.ResStatus.ToString() },
                {"@id_pelanggan", reservation.ResIDCust },
                {"@id_kamar", reservation.ResIDRoom }
            };

            ExecuteWrite(query, args);
        }
    }
}
