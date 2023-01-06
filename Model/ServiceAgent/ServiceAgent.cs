using PinusPengger.Model.DataAccessLayer;
using PinusPengger.Model.EntityModel;
using System;
using System.Collections.Generic;

namespace PinusPengger.Model.ServiceAgent
{
    /// <summary>
    /// Menyediakan layanan untuk mengakses model
    /// </summary>
    internal abstract class ServiceAgent
    {
        /// <summary>
        /// Mengambil data dari database
        /// </summary>
        public abstract void FetchData();
        /// <summary>
        /// Mendapatkan data yang telah diambil oleh method <see cref="FetchData"/>
        /// </summary>
        /// <returns>Kumpulan data</returns>
        public abstract IEnumerable<object> GetData();
        /// <summary>
        /// Meneruskan data sementara yang telah ditampung oleh model ke database
        /// </summary>
        /// <typeparam name="T">Class yang merupakan turunan dari <see cref="DataAccessLayer.IRepository"/></typeparam>
        /// <param name="repo">Data access layer dari tiap entitas</param>
        /// <param name="obj">Record yang ingin dimasukkan, dirubah, atau dihapus</param>
        /// <param name="mode">Mode penerusan record</param>
        /// <exception cref="ArgumentException"></exception>
        public static void FlushData<T>(T repo, object obj, Tag.FlushMode mode) where T : IRepository
        {
            // cek kondisi argumen
            if (!(repo is CustomerDAL || repo is HistoryDAL || repo is ReservationDAL))
            {
                throw new ArgumentException("Invalid Argument: repo must be of CustomerDAL, HistoryDAL, or Reservation DAL type", nameof(repo));
            }
            if (!(obj is Customer || obj is History || obj is Reservation))
            {
                throw new ArgumentException("Invalid Argument: obj must be of Customer, History, or Reservation type", nameof(obj));
            }
            // melaukan perubahan data berdasarkan penanda
            switch (mode)
            {
                case Tag.FlushMode.add:
                    repo.InsertRecord(obj);
                    break;
                case Tag.FlushMode.update:
                    repo.UpdateRecord(obj);
                    break;
                case Tag.FlushMode.delete:
                    repo.DeleteRecord(obj);
                    break;
                default:
                    break;
            }
        }
    }
}
