using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpDatabaseOpgave
{
    class Customers
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public CustomerTypeEnum CustomerType { get; set; }

        public Customers(string forNavn, string efternavn, string inputPhone, string inputEmail, CustomerTypeEnum inputCType)
        {
            FirstName = forNavn;
            LastName = efternavn;
            Phone = inputPhone;
            Email = inputEmail;
            CustomerType = inputCType;
        }

        public void InsertIntoDB()
        {
            string sql = $"insert into Customer values ('{FirstName}','{LastName}','{Phone}'," +
                $"'{Email}',{(int)CustomerType})";
            try
            {
                SQL.insert(sql);
                Console.WriteLine($"Kunden {FirstName} oprettet på tabellen");
            }
            catch (Exception)
            {
                Console.WriteLine("Der opstod en fejl i oprettelsen, kunden IKKE oprettet");
            }
        }
        public static void DeleteCustomer(int ID)
        {
            string sql = $"DELETE FROM Customer WHERE CustomerID = {ID};";
            try
            {
                if (SQL.delete(sql))
                {
                    SQL.delete($"DELETE FROM Booking WHERE CustomerID = {ID}");
                    Console.WriteLine($"Kunden med ID {ID} er slettet fra databasen." +
                        $"Kundens bookinger er tilsvarende slettet.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Der opstod en fejl i slet, kunden IKKE slettet");
            }
        }
        public static void UpdateCustomer(int ID, string forNavn, string efternavn, string inputPhone, string inputEmail)
        {
            string sql = $"UPDATE Customer " +
                $"SET FirstName = '{forNavn}', LastName = '{efternavn}', Phone = '{inputPhone}', Email = '{inputEmail}' " +
                $"WHERE CustomerID = {ID};";
            try
            {
                if (SQL.update(sql))
                {
                    Console.WriteLine($"Kunden med ID {ID} er blevet opdateret");
                }
                else
                {
                    Console.WriteLine($"Kunne ikke finde kunde med ID {ID}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Der opstod en fejl, kunne ikke opdatere kunden");
            }
        }

        public static void ReadTable()
        {
            SQL.DataReaderCustomers("Select * from Customer order by CustomerID");
        }
        public static void ReadTableInOrder()
        {
            SQL.DataReaderCustomers("Select * from Customer order by LastName");
        }

        public enum CustomerTypeEnum
        {
            Online,
            InStore,
        }
    }
}
