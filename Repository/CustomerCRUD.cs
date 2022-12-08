using PinusPengger.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PinusPengger.Repository
{
    internal class CustomerCRUD : DatabaseCRUD<Customer>
    {
        public override void DeleteRecord(Customer customer)
        {
            const string query = "DELETE FROM pelanggan WHERE id = @id";

            var args = new Dictionary<string, object>
            {
                {"@id", customer.CustID }
            };

            ExecuteWrite(query, args);
        }

        public override void InsertRecord(Customer customer)
        {
            const string query = "INSERT INTO pelanggan(nik, nama, tanggal_lahir, telp) VALUES(@nik, @nama, @tanggal_lahir, @telp)";

            var args = new Dictionary<string, object>
            {
                {"@nik", customer.CustNIK },
                {"@nama", customer.CustName },
                {"@tanggal_lahir", customer.CustBirthDate},
                {"@telp", customer.CustPhone}
            };

            ExecuteWrite(query, args);
        }

        public override List<Customer> ReadData()
        {
            var result = new List<Customer>();

            const string query = "SELECT * FROM pelanggan";

            SqlDataReader rdr = ExecuteRead(query);

            while (rdr.Read())
            {
                var customer = new Customer
                {
                    CustID = Convert.ToInt32(rdr["id"]),
                    CustNIK = rdr["nik"].ToString(),
                    CustName = rdr["nama"].ToString(),
                    CustBirthDate = DateOnly.FromDateTime(Convert.ToDateTime(rdr["tanggal_lahir"])),
                    CustPhone = rdr["telp"].ToString()
                };
                result.Add(customer);
            }

            return result;
        }

        public override void UpdateRecord(Customer customer)
        {
            const string query = "UPDATE pelanggan SET nik = @nik, nama = @nama, tanggal_lahir = @tanggal_lahir, telp = @telp WHERE id = @id";

            var args = new Dictionary<string, object>
            {
                {"@id", customer.CustID },
                {"@nik", customer.CustNIK},
                {"@nama", customer.CustName},
                {"@tanggal_lahir", customer.CustBirthDate},
                {"@telp", customer.CustPhone}
            };

            ExecuteWrite(query, args);
        }
    }
}
