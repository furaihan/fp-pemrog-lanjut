﻿using PinusPengger.Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace PinusPengger.DataAccessLayer
{
    /// <summary>
    /// Provides CRUD mechanism for Reservation table
    /// </summary>
    public class ReservationDAL : IRepository
    {
        /// <summary>
        /// Initializes an instance of <see cref="ReservationDAL"/> class
        /// </summary>
        public ReservationDAL()
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ToString());
            Connection.Open();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public SqlConnection Connection { get; set; }

        /// <summary>
        /// Executes a DML (Data Manipulation Language) command for the methods <see cref="InsertRecord(object)"/>,
        /// <see cref="UpdateRecord(object)"/>, and <see cref="DeleteRecord(object)"/>
        /// </summary>
        /// <param name="query">The query to be executed by the database</param>
        /// <param name="args">Arguments required by the query</param>
        private void ExecuteDMLCommand(string query, Dictionary<string, object> args)
        {
            SqlTransaction tran = Connection.BeginTransaction();

            try
            {
                using (var cmd = new SqlCommand(query, Connection, tran))
                {
                    foreach (var pair in args)
                    {
                        cmd.Parameters.AddWithValue(pair.Key, pair.Value);
                    }
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                }
            }
            catch (Exception)
            {
                tran.Rollback();
            }
            finally
            {
                tran.Dispose();
            }
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public List<object> ReadData()
        {
            var result = new List<Reservation>();

            string query = ConfigurationManager.AppSettings["ReservationDAL:ReadData"] ?? string.Empty;

            using (var cmd = new SqlCommand(query, Connection))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var reservation = new Reservation

                        {
                            ReservationID = rdr.GetInt32(0),
                            ReservationCode = rdr.GetString(1),
                            NumberOfGuests = rdr.GetByte(2),
                            Checkin = rdr.GetDateTime(3),
                            Checkout = rdr.GetDateTime(4),
                            ReservationStatus = (Tag.ReservationStatus)Enum.Parse(typeof(Tag.ReservationStatus), rdr.GetString(5)),
                            CustomerID = rdr.GetInt32(6),
                            RoomID = rdr.GetInt32(7)
                        };
                        result.Add(reservation);
                    }
                }
            }

            return result.Select(x => (object)x).ToList();
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="obj"><inheritdoc/></param>
        public void InsertRecord(object obj)
        {
            string query = ConfigurationManager.AppSettings["ReservationDAL:InsertRecord"] ?? string.Empty;

            if (obj is Reservation reservation)
            {
                var args = new Dictionary<string, object>
                {
                    {"@reservationCode", reservation.ReservationCode },
                    {"@numberOfGuests", reservation.NumberOfGuests },
                    {"@checkin", reservation.Checkin },
                    {"@checkout", reservation.Checkout },
                    {"@reservationStatus", reservation.ReservationStatus.ToString() },
                    {"@customerID", reservation.CustomerID },
                    {"@roomID", reservation.RoomID }
                };
                ExecuteDMLCommand(query, args);
            }
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="obj"><inheritdoc/></param>
        public void UpdateRecord(object obj)
        {
            string query = ConfigurationManager.AppSettings["ReservationDAL:UpdateRecord"] ?? string.Empty;

            if (obj is Reservation reservation)
            {
                var args = new Dictionary<string, object>
                {
                    {"@reservationID", reservation.ReservationID },
                    {"@reservationCode", reservation.ReservationCode },
                    {"@numberOfGuests", reservation.NumberOfGuests },
                    {"@checkin", reservation.Checkin },
                    {"@checkout", reservation.Checkout },
                    {"@reservationStatus", reservation.ReservationStatus.ToString() },
                    {"@customerID", reservation.CustomerID },
                    {"@roomID", reservation.RoomID }
                };
                ExecuteDMLCommand(query, args);
            }
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="obj"><inheritdoc/></param>
        public void DeleteRecord(object obj)
        {
            string query = ConfigurationManager.AppSettings["ReservationDAL:DeleteRecord"] ?? string.Empty;

            if (obj is Reservation reservation)
            {
                var args = new Dictionary<string, object>
                {
                    {"@reservationID", reservation.ReservationID }
                };
                ExecuteDMLCommand(query, args);
            }
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Connection.Close();
            Connection.Dispose();
        }
    }
}
