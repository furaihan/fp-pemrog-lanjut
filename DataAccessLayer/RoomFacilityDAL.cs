﻿using PinusPengger.Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace PinusPengger.DataAccessLayer
{
    /// <summary>
    /// Mekanisme CRUD tabel fasilitas kamar
    /// </summary>
    public class RoomFacilityDAL : IRepository
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
        /// Menginisiasi objek <see cref="RoomFacilityDAL"/>
        /// </summary>
        public RoomFacilityDAL()
        {
            Connect(ConfigurationManager.ConnectionStrings, 0);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public SqlConnection Connection { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public List<object> ReadData()
        {
            var result = new List<RoomFacility>();

            string query = ConfigurationManager.AppSettings["RoomFacilityDAL:ReadData"] ?? string.Empty;

            using (var cmd = new SqlCommand(query, Connection))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var roomFacility = new RoomFacility()
                        {
                            RoomType = (Tag.RoomType)Enum.Parse(typeof(Tag.RoomType), rdr.GetString(0)),
                            Bed = rdr.GetString(1),
                            Internet = rdr.GetString(2)
                        };
                        result.Add(roomFacility);
                    }
                }
            }

            return result.Select(x => (object)x).ToList();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="obj"><inheritdoc/></param>
        /// <exception cref="NotImplementedException"></exception>
        public void InsertRecord(object obj)
        {
            throw new NotImplementedException();
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