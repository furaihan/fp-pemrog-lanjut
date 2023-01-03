using System.Configuration;
using System.Data.SqlClient;
using TestingDatabase.Model.EntityModel;

namespace TestingDatabase.Model.DataAccessLayer
{
    internal class RoomFacilityOtherDAL : IRepository, IDisposable
    {

        public RoomFacilityOtherDAL()
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
            Connection.Open();
        }

        public SqlConnection Connection { get; set; }

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
