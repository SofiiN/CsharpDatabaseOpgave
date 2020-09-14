using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CsharpDatabaseOpgave
{
    static class SQL
    {
        private static string ConnectionString = "Data Source=localhost;Initial Catalog=Cinema; " +
            "Integrated Security=SSPI;Connect Timeout=5;Encrypt=False;" +
            "TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static bool SqlConnectionOK()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }

        public static void insert(string sql)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
        }
        public static bool delete(string sql)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                return cmd.ExecuteNonQuery() != 0;
            }
        }
        public static bool update(string sql)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                return cmd.ExecuteNonQuery() != 0;
            }
        }

        public static DataTable ReadTable(string sql)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                DataTable records = new DataTable();

                using (SqlDataAdapter a = new SqlDataAdapter(sql, con))
                {
                    con.Open();
                    a.Fill(records);
                }

                return records;
            }
        }

        public static void DataReaderCustomers(string sqlCom)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlCom, con);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int CustomerID = reader.GetInt32(0);
                    string FirstName = reader.GetString(1);
                    string LastName = reader.GetString(2);
                    string Phone = reader.GetString(3);
                    string Email = reader.GetString(4);
                    Customers.CustomerTypeEnum CType = (Customers.CustomerTypeEnum)reader.GetInt32(5);

                    Console.WriteLine($"Id: {CustomerID}. navn: {FirstName} {LastName}. mobil: {Phone}. - email: " +
                        $"{Email}. - type: {CType}.");
                }
            }
        }
        public static void CustomersOrderChecker(string sqlCom)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlCom, con);

                SqlDataReader reader = cmd.ExecuteReader();

                Console.Write("Bookings for customer with ID: ");

                while (reader.Read())
                {
                    int CustomerID = reader.GetInt32(0);
                    string Movie = reader.GetString(1);
                    DateTime PlayDate = reader.GetDateTime(2);
                    int SeatCount = reader.GetInt32(3);
                    Booking.BookingTypeEnum BookingType = (Booking.BookingTypeEnum)reader.GetInt32(4);

                    Console.WriteLine($"{CustomerID}.\n" +
                        $"Movie: {Movie}. Play Time: {PlayDate}. Seats: " +
                        $"{SeatCount}. - Booking metode: {BookingType}");
                }
            }
        }
        public static void DisplayAllMovies(string sqlCom)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlCom, con);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int MovieID = reader.GetInt32(0);
                    string MovieName = reader.GetString(1);
                    DateTime PlayDateAndTime = reader.GetDateTime(2);
                    int Duaration = reader.GetInt32(3);

                    Console.WriteLine($"Movie ID: {MovieID}. Film navn: {MovieName}. - Play time: {PlayDateAndTime}." +
                        $" - Duaration: {Duaration}");
                }
            }
        }

        public static bool CustomerIDExists(int ID)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"Select * from Customer where CustomerID = {ID}", con);

                SqlDataReader reader = cmd.ExecuteReader();

                return reader.HasRows;
            }
        }
        public static bool MovieExists(int ID)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"Select * from Movies where MovieID = {ID}", con);

                SqlDataReader reader = cmd.ExecuteReader();

                return reader.HasRows;
            }
        }
    }
}
