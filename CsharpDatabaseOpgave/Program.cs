using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpDatabaseOpgave
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Velkommen til WeCinema. - Vælg en af følgende valgmuligheder.\n");

                Console.WriteLine("Kunde releterede oplsyninger - Tast [K]\n" +
                    "Bestil bilet - Tast [B]");
                ConsoleKeyInfo inputKey = Console.ReadKey(true);

                switch (inputKey.Key)
                {
                    case ConsoleKey.K:
                        Layout.CustomerMenu();
                        break;
                    case ConsoleKey.B:

                        break;
                    case ConsoleKey.Escape:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Det intastede bogstav er ugyldigt. Prøv igen");
                        break;
                }
            } while (running == true);




            //Customers test = new Customers("Børge", "Olesen", "19191919", "test3@test3.dk", Customers.CustomerTypeEnum.Online);
            //Customers test2 = new Customers("Jens", "Jensen", "19191919", "test3@test3.dk", Customers.CustomerTypeEnum.InStore);
            //Customers test3 = new Customers("Søren", "Karlsen", "19191919", "test3@test3.dk", Customers.CustomerTypeEnum.InStore);

            //test.InsertIntoDB();
            //test2.InsertIntoDB();
            //test3.InsertIntoDB();


            //Customers.ReadTable();
            //Customers.ReadTableInOrder();

            ////Customers.DeleteCustomer(0);

            ////Customers.UpdateCustomer(2, "Anders", "Bosen", "18181818", "noget@nogetandet.dk");
            ////Customers.UpdateCustomer(0, "Anders", "Bosen", "18181818", "noget@nogetandet.dk");

            //Booking newbook = new Booking(2, "x", "2020-9-18 10:00:00", 3, Booking.BookingTypeEnum.Forudbetalt);
            //newbook.InsertIntoDB();
            //Booking.CustomerBookings(2);

            //Movie test4 = new Movie("TestFilm", "2020-9-18 10:00:00", 2);
            //test4.InsertIntoDB();

            //Movie.DeleteMovie(1);


            /* MOVIES
            Movie M1 = new Movie("Tenet", "2020-9-11 14:30:00", 2);
            M1.InsertIntoDB();
            Movie M2 = new Movie("GreenLand", "2020-9-16 18:30:00", 1);
            M2.InsertIntoDB();
            Movie M3 = new Movie("After We Collided", "2020-9-23 10:00:00", 2);
            M3.InsertIntoDB();
            Movie M4 = new Movie("Blokhavn", "2020-10-12 15:30:00", 2);
            M4.InsertIntoDB(); */
        }
    }
}
