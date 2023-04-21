using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PinusPengger.DataAccessLayer
{
    /// <summary>
    /// Provides CRUD mechanism.
    /// </summary>
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// Represents database connection.
        /// </summary>
        SqlConnection Connection { get; set; }

        /// <summary>
        /// Reads data from database.
        /// </summary>
        /// <returns>List of data.</returns>
        List<object> ReadData();

        /// <summary>
        /// Inserts record into database.
        /// </summary>
        /// <param name="obj">Record to be inserted.</param>
        void InsertRecord(object obj);

        /// <summary>
        /// Updates record in database.
        /// </summary>
        /// <param name="obj">Record to be updated.</param>
        void UpdateRecord(object obj);

        /// <summary>
        /// Deletes record from database.
        /// </summary>
        /// <param name="obj">Record to be deleted.</param>
        void DeleteRecord(object obj);
    }

}
