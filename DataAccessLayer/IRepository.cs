using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PinusPengger.DataAccessLayer
{
    /// <summary>
    /// Menyediakan mekanisme CRUD 
    /// </summary>
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// Merepresentasikan koneksi database
        /// </summary>
        SqlConnection Connection { get; set; }

        /// <summary>
        /// Membaca data dari database
        /// </summary>
        /// <returns>Daftar data</returns>
        List<object> ReadData();
        /// <summary>
        /// Memasukkan record ke database
        /// </summary>
        /// <param name="obj">Record yang akan dimasukkan</param>
        void InsertRecord(object obj);
        /// <summary>
        /// Memperbarui record ke database
        /// </summary>
        /// <param name="obj">Record yang akan diperbarui</param>
        void UpdateRecord(object obj);
        /// <summary>
        /// Menghapus record dari database
        /// </summary>
        /// <param name="obj">Record yang akan dihapus</param>
        void DeleteRecord(object obj);
    }
}
