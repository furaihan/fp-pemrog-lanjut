using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinusPengger.Repository
{
    abstract class DatabaseCRUD<T>
    {
        protected void ExecuteWrite(string query, Dictionary<string, object> args)
        {
            // membuat koneksi ke database
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=db_hotel;Integrated Security=True";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // membuat transaksi
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // eksekusi kueri
                    using (var cmd = new SqlCommand(query, conn, tran))
                    {
                        foreach (var pair in args) cmd.Parameters.AddWithValue(pair.Key, pair.Value);
                        cmd.ExecuteNonQuery();
                        tran.Commit();
                    }
                }
                catch (Exception e)
                {
                    tran.Rollback();
                }
                conn.Close();
            }
        }
        protected SqlDataReader ExecuteRead(string query)
        {
            // membuat koneksi ke database
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=db_hotel;Integrated Security=True";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                conn.Close();
                return rdr;
            }
        }
        public abstract void InsertRecord(T obj);
        public abstract void UpdateRecord(T obj);
        public abstract void DeleteRecord(T obj);
        public abstract ObservableCollection<T> ReadData();
    }
}
