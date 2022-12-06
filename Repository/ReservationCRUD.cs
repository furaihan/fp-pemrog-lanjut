using PinusPengger.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinusPengger.Repository
{
    class ReservationCRUD : DatabaseCRUD<Reservation>
    {
        public override void DeleteRecord(Reservation reservation)
        {
            const string query = "DELETE FROM reservasi WHERE id = @id";

            var args = new Dictionary<string, object>
            {
                {"@id", reservation.ID },
            };

            ExecuteWrite(query, args);
        }

        public override void InsertRecord(Reservation reservation)
        {
            const string query = "INSERT INTO reservasi(kode_reservasi, checkin, checkout, status_reservasi, pelanggan, kamar) VALUES(@kodeReservasi, @checkin, @checkout, @statusReservasi, @id_pelanggan, @id_kamar)";

            var args = new Dictionary<string, object>
            {
                {"@kodeReservasi", reservation.Code },
                {"@checkin", reservation.CheckIn },
                {"@checkout", reservation.CheckOut },
                {"@statusReservasi", Convert.ToInt16(reservation.Status) },
                {"@id_pelanggan", reservation.IDCustomer },
                {"@id_kamar", reservation.IDRoom },
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
                    ID = Convert.ToInt32(rdr["id"]),
                    Code = rdr["kode_reservasi"].ToString(),
                    CheckIn = Convert.ToDateTime(rdr["checkin"]),
                    CheckOut = Convert.ToDateTime(rdr["checkout"]),
                    Status = (ReservationStatus)rdr["status_reservasi"],
                    IDCustomer = Convert.ToInt32(rdr["pelanggan"]),
                    IDRoom = Convert.ToInt32(rdr["kamar"])
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
                {"@id", reservation.ID },
                {"@kodePemesanan", reservation.Code },
                {"@checkin", reservation.CheckIn },
                {"@checkout", reservation.CheckOut },
                {"@statusPemesanan", Convert.ToInt16(reservation.Status) },
                {"@id_pelanggan", reservation.IDCustomer },
                {"@id_kamar", reservation.IDRoom },
            };

            ExecuteWrite(query, args);
        }
    }
}
