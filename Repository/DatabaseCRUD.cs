using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PinusPengger.Repository
{
    internal abstract class DatabaseCRUD<T>
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

                // eksekusi kueri
                var cmd = new SqlCommand(query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                conn.Close();
                return rdr;
            }
        }
        public abstract void DeleteRecord(T obj);
        public abstract void InsertRecord(T obj);
        public abstract List<T> ReadData();
        public abstract void UpdateRecord(T obj);
    }
}
