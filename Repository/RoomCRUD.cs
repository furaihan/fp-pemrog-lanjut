using PinusPengger.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace PinusPengger.Repository
{
    class RoomCRUD : DatabaseCRUD<Room>
    {
        public override void DeleteRecord(Room room)
        {
            const string query = "DELETE FROM kamar WHERE id = @id";

            var args = new Dictionary<string, object>
            {
                {"@id", room.ID}
            };

            ExecuteWrite(query, args);
        }

        public override void InsertRecord(Room room)
        {
            const string query = "INSERT INTO kamar(kode, nomor, lantai, tipe) VALUES(@kode, @nomor, @lantai, @tipe)";

            var args = new Dictionary<string, object>
            {
                {"@kode", room.Code },
                {"@lantai", room.Floor },
                {"@nomor", room.Number },
                {"@tipe", Convert.ToInt16(room.Type)}
            };

            ExecuteWrite(query, args);
        }

        public override ObservableCollection<Room> ReadData()
        {
            var result = new List<Room>();

            const string query = "SELECT * FROM kamar";

            SqlDataReader rdr = ExecuteRead(query);

            while (rdr.Read()) 
            {
                var room = new Room()
                {
                    ID = Convert.ToInt32(rdr["id"]),
                    Code = rdr["kode"].ToString(),
                    Number = Convert.ToInt16(rdr["nomor"]),
                    Floor = Convert.ToInt16(rdr["lantai"]),
                    Type = (RoomType)rdr["tipe"]
                };
                result.Add(room);
            }

            var oc = new ObservableCollection<Room>();
            result.ForEach(x => oc.Add(x));

            return oc;
        }

        public override void UpdateRecord(Room room)
        {
            const string query = "UPDATE kamar SET kode = @kode, nomor = @nomor, lantai = @lantai, tipe = @tipe WHERE id = @id";

            var args = new Dictionary<string, object>
            {
                {"@id", room.ID },
                {"@kode", room.Code },
                {"@lantai", room.Floor },
                {"@nomor", room.Number },
                {"@tipe", Convert.ToInt16(room.Type) }
            };

            ExecuteWrite(query, args);
        }
    }
}
