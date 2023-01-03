using System.Data.SqlClient;

namespace TestingDatabase.Model.DataAccessLayer
{
    internal interface IRepository
    {
        SqlConnection Connection { get; set; }
        List<object> ReadData();
        void InsertRecord(object obj);
        void UpdateRecord(object obj);
        void DeleteRecord(object obj);

    }
}
