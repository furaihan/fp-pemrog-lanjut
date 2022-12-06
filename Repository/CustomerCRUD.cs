using PinusPengger.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace PinusPengger.Repository
{
    class CustomerCRUD : DatabaseCRUD<Customer>
    {
        public override void DeleteRecord(Customer customer)
        {
            const string query = "DELETE FROM pelanggan WHERE id = @id";

            var args = new Dictionary<string, object>
            {
                {"@id", customer.ID },
            };

            ExecuteWrite(query, args);
        }

        public override void InsertRecord(Customer customer)
        {
            const string query = "INSERT INTO pelanggan(nik, nama, tanggal_lahir, telp) VALUES(@nik, @name, @birthDate, @phoneNumber)";

            var args = new Dictionary<string, object>
            {
                {"@nik", customer.NIK },
                {"@name", customer.Name },
                {"@birthDate", customer.BirthDate },
                {"@phoneNumber", customer.PhoneNumber }
            };

            ExecuteWrite(query, args);
        }

        public override ObservableCollection<Customer> ReadData()
        {
            var result = new List<Customer>();

            const string query = "SELECT * FROM pelanggan";

            SqlDataReader rdr = ExecuteRead(query);

            while (rdr.Read())
            {
                var customer = new Customer
                {
                    ID = Convert.ToInt32(rdr["id"]),
                    NIK = rdr["nik"].ToString(),
                    Name = rdr["nama"].ToString(),
                    BirthDate = DateOnly.FromDateTime(Convert.ToDateTime(rdr["tanggal_lahir"])),
                    PhoneNumber = rdr["telp"].ToString()
                };
                result.Add(customer);
            }

            var oc = new ObservableCollection<Customer>();
            result.ForEach(x => oc.Add(x));

            return oc;
        }

        public override void UpdateRecord(Customer customer)
        {
            const string query = "UPDATE pelanggan SET nik = @nik, nama = @name, tanggal_lahir = @birthDate, telp = @phoneNumber WHERE id = @id";

            var args = new Dictionary<string, object>
            {
                {"@id", customer.ID },
                {"@nik", customer.NIK },
                {"@name", customer.Name },
                {"@birthDate", customer.BirthDate },
                {"@phoneNumber", customer.PhoneNumber }
            };

            ExecuteWrite(query, args);
        }
    }
}
