using System.Configuration;
using System.Data.SqlClient;
using TestingDatabase.Model.EntityModel;

namespace TestingDatabase.Model.DataAccessLayer
{
    internal class RoomDAL : IRepository, IDisposable
    {
        public RoomDAL()
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
            Connection.Open();
        }

        public SqlConnection Connection { get; set; }

        public List<object> ReadData()
        {
            var result = new List<Room>();

            string query = ConfigurationManager.AppSettings["RoomDAL:ReadData"] ?? string.Empty;

            using (var cmd = new SqlCommand(query, Connection))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var room = new Room
                        {
                            RoomID = rdr.GetInt32(0),
                            RoomCode = rdr.GetString(1),
                            RoomFloor = rdr.GetByte(2),
                            RoomNumber = rdr.GetByte(3),
                            SquareMeter = rdr.GetByte(4),
                            RoomType = (Tag.RoomType)Enum.Parse(typeof(Tag.RoomType), rdr.GetString(5))
                        };
                        result.Add(room);
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
