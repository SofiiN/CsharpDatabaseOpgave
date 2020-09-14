using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpDatabaseOpgave
{
    class Booking
    {
        public int CustomerID { get; set; }
        public int MovieID { get; set; }
        public string PlayDateAndTime { get; set; }
        public int SeatCount { get; set; }
        public BookingTypeEnum BookingType { get; set; }

        public Booking (int inputCID, int inputMovieID, string inputDateTime, int inputSC, BookingTypeEnum inputBT)
        {
            CustomerID = inputCID;
            MovieID = inputMovieID;
            PlayDateAndTime = inputDateTime;
            SeatCount = inputSC;
            BookingType = inputBT;
        }

        public void InsertIntoDB()
        {

            string sql = $"insert into Booking values ({CustomerID},{MovieID},'{PlayDateAndTime}'," +
                $"{SeatCount},{(int)BookingType})";
            try
            {
                SQL.insert(sql);
                Console.WriteLine($"Booking for {SeatCount} sidepladser er blevet godkendt.");
            }
            catch (Exception)
            {
                Console.WriteLine("Der opstod en fejl i bestilling.");
            }
        }
        public static void CustomerBookings(int CustomerID)
        {
            SQL.CustomersOrderChecker($"Select * from Booking where CustomerID = {CustomerID}");
        }

        public enum BookingTypeEnum
        {
            Resevertion,
            Forudbetalt
        }
	}
}
