using PinusPengger.DataAccessLayer;
using PinusPengger.Model.EntityModel;
using System.Collections.Generic;
using System;

namespace PinusPengger.ServiceAgent
{
    /// <summary>
    /// Provides services for accessing the model.
    /// </summary>
    public abstract class ServiceAgent
    {
        /// <summary>
        /// Retrieves data from the database.
        /// </summary>
        public abstract void FetchData();

        /// <summary>
        /// Gets the data that has been retrieved by the <see cref="FetchData"/> method.
        /// </summary>
        /// <returns>A collection of data.</returns>
        public abstract IEnumerable<object> GetData();

        /// <summary>
        /// Flushes the temporary data that has been stored by the model to the database.
        /// </summary>
        /// <typeparam name="T">A class that is derived from <see cref="DataAccessLayer.IRepository"/>.</typeparam>
        /// <param name="repo">The data access layer for each entity.</param>
        /// <param name="obj">The record that you want to insert, update, or delete.</param>
        /// <param name="mode">The mode for flushing the record.</param>
        /// <exception cref="ArgumentException">Thrown when the input arguments are invalid.</exception>
        public static void FlushData<T>(T repo, object obj, Tag.FlushMode mode) where T : IRepository
        {
            // Check the argument conditions.
            if (!(repo is CustomerDAL || repo is HistoryDAL || repo is ReservationDAL))
            {
                throw new ArgumentException("Invalid Argument: repo must be of CustomerDAL, HistoryDAL, or Reservation DAL type", nameof(repo));
            }
            if (!(obj is Customer || obj is History || obj is Reservation))
            {
                throw new ArgumentException("Invalid Argument: obj must be of Customer, History, or Reservation type", nameof(obj));
            }

            // Perform the data changes based on the tag.
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

            repo.Dispose();
        }
    }
}
