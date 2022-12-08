﻿using PinusPengger.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace PinusPengger.Repository
{
    internal class RoomCRUD : DatabaseCRUD<Room>
    {
        public override void DeleteRecord(Room room)
        {
            const string query = "DELETE FROM kamar WHERE id = @id";

            var args = new Dictionary<string, object>
            {
                {"@id", room.RoomID}
            };

            ExecuteWrite(query, args);
        }

        public override void InsertRecord(Room room)
        {
            const string query = "INSERT INTO kamar(kode, nomor, lantai, tipe) VALUES(@kode, @nomor, @lantai, @tipe)";

            var args = new Dictionary<string, object>
            {
                {"@kode", room.RoomCode },
                {"@lantai", room.RoomFloor },
                {"@nomor", room.RoomNumber },
                {"@tipe", room.RoomType.ToString()}
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
                var room = new Room
                {
                    RoomID = Convert.ToInt32(rdr["id"]),
                    RoomCode = rdr["kode"].ToString(),
                    RoomNumber = Convert.ToInt16(rdr["nomor"]),
                    RoomFloor = Convert.ToInt16(rdr["lantai"]),
                    RoomType = (RoomType)rdr["tipe"]
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
                {"@id", room.RoomID },
                {"@kode", room.RoomCode },
                {"@lantai", room.RoomFloor },
                {"@nomor", room.RoomNumber },
                {"@tipe", room.RoomType.ToString()}
            };

            ExecuteWrite(query, args);
        }
    }
}