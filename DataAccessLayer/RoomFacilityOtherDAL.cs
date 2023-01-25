using PinusPengger.Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace PinusPengger.DataAccessLayer
{
    /// <summary>
    /// Mekanisme CRUD tabel fasilitas lainnya
    /// </summary>
    public class RoomFacilityOtherDAL : IRepository
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
        /// Menginisialisasi objek <see cref="RoomFacilityOtherDAL"/>
        /// </summary>
        public RoomFacilityOtherDAL()
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
            var result = new List<RoomFacilityOther>();

            string query = ConfigurationManager.AppSettings["RoomFacilityOtherDAL:ReadData"] ?? string.Empty;

            using (var cmd = new SqlCommand(query, Connection))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var roomFacilityOther = new RoomFacilityOther()
                        {
                            NameOfFacility = rdr.GetString(0),
                            RoomType = (Tag.RoomType)Enum.Parse(typeof(Tag.RoomType), rdr.GetString(1))
                        };
                        result.Add(roomFacilityOther);
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
