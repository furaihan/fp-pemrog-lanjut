using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using Newtonsoft.Json;

namespace PinusPengger.Repository
{
    /// <summary>
    /// Membuat koneksi ke database dan meneruskan perintah
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal abstract class DatabaseCRUD<T>
    {
        /// <summary>
        /// Mengeksekusi perintah DML ke database
        /// </summary>
        /// <param name="query"></param>
        /// <param name="args"></param>
        protected void ExecuteDMLCommand(string query, Dictionary<string, object> args)
        {
            //membaca connectionString dari file json
            Debug.WriteLine("Json Start");
            dynamic appData = JsonConvert.DeserializeObject(System.IO.File.ReadAllText("config.json"));
            string cs = appData.PinusPengger.connectionString;
            Debug.WriteLine(cs);
            // membuat koneksi ke database
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=db_hotel;Integrated Security=True";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // membuat transaksi
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // eksekusi perintah
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

        /// <summary>
        /// Mengeksekusi perintah DQL ke database
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Data mentah <see cref="SqlDataReader"/></returns>
        protected SqlDataReader ExecuteDQLCommand(string query)
        {
            // membuat koneksi ke database
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=db_hotel;Integrated Security=True";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // eksekusi perintah
                var cmd = new SqlCommand(query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                conn.Close();
                return rdr;
            }
        }

        /// <summary>
        /// Menghapus record di dalam tabel
        /// </summary>
        /// <param name="obj">Sebuah object di dalam tabel yang akan dihapus</param>
        public abstract void DeleteRecord(T obj);

        /// <summary>
        /// Memasukkan record ke dalam tabel
        /// </summary>
        /// <param name="obj">Sebuah object yang akan dimasukkan ke dalam tabel</param>
        public abstract void InsertRecord(T obj);

        /// <summary>
        /// Membaca semua record di dalam tabel
        /// </summary>
        /// <returns>Daftar record dari tabel dalam bentuk <see cref="List{T}"/></returns>
        public abstract List<T> ReadData();

        /// <summary>
        /// Memperbarui record di dalam tabel
        /// </summary>
        /// <param name="obj">Sebuah object di dalam tabel yang akan diperbarui</param>
        public abstract void UpdateRecord(T obj);
    }
}
