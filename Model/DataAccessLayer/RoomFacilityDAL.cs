using System.Configuration;
using System.Data.SqlClient;
using TestingDatabase.Model.EntityModel;

namespace TestingDatabase.Model.DataAccessLayer
{
    internal class RoomFacilityDAL : IRepository, IDisposable
    {
        public RoomFacilityDAL()
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
            Connection.Open();
        }

        public SqlConnection Connection { get; set; }

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

        public void InsertRecord(object obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecord(object obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecord(object obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Connection.Close();
            Connection.Dispose();
        }
    }
}
