using PinusPengger.Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace PinusPengger.DataAccessLayer
{
    /// <summary>
    /// Provides CRUD mechanism for room facilities table
    /// </summary>
    public class RoomFacilityDAL : IRepository
    {
        /// <summary>
        /// Initializes an instance of <see cref="RoomFacilityDAL"/> class
        /// </summary>
        public RoomFacilityDAL()
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
            Connection.Open();
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
