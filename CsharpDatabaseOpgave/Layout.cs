using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpDatabaseOpgave
{
    class Layout
    {
        public static void CustomerMenu()
        {
            Console.Clear();

            bool running = true;
            do
            {
                Console.WriteLine("Vælge en af følgende valgmuligheder:\n\n" +
                "Tast [K] - For at se alle kunder\n" +
                "Tast [E] - For at se alle kunder, sorteret på efternavn\n\n" +
                "" +
                "Tast [O] - For at oprette en ny kunde\n" +
                "Tast [D] - For at slette en kunde\n" +
                "Tast [U] - For at update en kunde");

                ConsoleKeyInfo inputKey = Console.ReadKey(true);

                switch (inputKey.Key)
                {
                    case ConsoleKey.K:
                        Console.Clear();
                        Customers.ReadTable();

                        Console.WriteLine("\nTryk på en tast for at gå til hovedmenu");
                        Console.ReadKey(true);
                        Console.Clear();
                        break;

                    case ConsoleKey.E:
                        Console.Clear();
                        Customers.ReadTableInOrder();

                        Console.WriteLine("\nTryk på en tast for at gå til hovedmenu");
                        Console.ReadKey(true);
                        Console.Clear();
                        break;

                    case ConsoleKey.O:
                        Console.Clear();
                        Console.Write("Indtast informationer:\n\n" +
                            "Fornavn:");
                        string fName = Console.ReadLine();

                        Console.Write("Efternavn:");
                        string eName = Console.ReadLine();

                        Console.Write("Mobil:");
                        string mobil = Console.ReadLine();

                        Console.Write("Email:");
                        string email = Console.ReadLine();

                        string cType;
                        int opretVal;
                        do
                        {
                            Console.WriteLine("Vælg bruger type:   [0] - Online user. [1] - In store");
                            cType = Console.ReadLine();

                            if (!int.TryParse(cType, out opretVal))
                            {
                                Console.WriteLine("Den indtastede værde er ugyldig");
                            }
                        } while (opretVal != 0 && opretVal != 1);

                        Customers kunde = new Customers(fName, eName, mobil, email, (Customers.CustomerTypeEnum)opretVal);
                        kunde.InsertIntoDB();

                        Console.WriteLine("Tryk på en tast for at komme tilbage til hovedmenuen");
                        Console.ReadKey(true);

                        Console.Clear();
                        break;

                    case ConsoleKey.D:
                        int deleteVal;
                        bool deleteAnswer = false;
                        do
                        {
                            Console.WriteLine("Indtsast ID på person du ønsker at slette.");
                            string deleteID = Console.ReadLine();

                            if (int.TryParse(deleteID, out deleteVal))
                            {
                                deleteAnswer = SQL.CustomerIDExists(deleteVal);
                            }
                            else
                            {
                                Console.WriteLine("Den indtastede værde er ugyldig");
                            }

                        } while (!deleteAnswer);

                        Customers.DeleteCustomer(deleteVal);
                        Console.ReadKey(true);
                        Console.Clear();

                        break;

                    case ConsoleKey.U:
                        int updateVal;
                        bool updateAnswer = false;
                        do
                        {
                            Console.WriteLine("Indtsast ID på person du ønsker at rette. Følg vejledning derefter\n");
                            string inputID = Console.ReadLine();

                            if (int.TryParse(inputID, out updateVal))
                            {
                                updateAnswer = SQL.CustomerIDExists(updateVal);

                                if (!updateAnswer)
                                {
                                    Console.WriteLine("Det intastede ID findes ikke i databasen\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Den indtastede værde er ugyldig");
                            }

                        } while (!updateAnswer);


                        Console.Write("Fornavn:");
                        string updateFName = Console.ReadLine();

                        Console.Write("Efternavn:");
                        string updateEName = Console.ReadLine();

                        Console.Write("Mobil:");
                        string updateMobil = Console.ReadLine();

                        Console.WriteLine("Email:");
                        string updateEmail = Console.ReadLine();

                        Customers.UpdateCustomer(updateVal, updateFName, updateEName, updateMobil, updateEmail);
                        Console.WriteLine("Tryk på en tast for at gå til hovedmenu");
                        Console.ReadKey(true);
                        break;

                    case ConsoleKey.Escape:
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Ugyldig indtastning");
                        break;
                }
            } while (running == true);
        }

        public static void BestillingsMenu()
        {
            bool running = true;
            do
            {
                Console.WriteLine("Vælge en af følgende valgmuligheder:\n\n" +
                "Tast [F] - For at se alle film\n" +
                "Tast [B] - For at bestille en bilet\n\n" +
                "" +
                "Tast [L] - For at se alle bestillinger for en kunde (Via kunde ID)");

                ConsoleKeyInfo inputKey = Console.ReadKey(true);

                switch (inputKey.Key)
                {
                    case ConsoleKey.F:
                        Console.Clear();
                        Movie.SeeListOfMovie();

                        Console.WriteLine("\nTryk på en tast for at gå til hovedmenu");
                        Console.ReadKey(true);
                        Console.Clear();

                        break;
                    case ConsoleKey.B:
                        int customerID;
                        bool customerIDAnswer = false;
                        do
                        {
                            Console.WriteLine("Indtast ID på kunde du ønsker at se bookings for\n");
                            string inputID = Console.ReadLine();

                            if (int.TryParse(inputID, out customerID))
                            {
                                customerIDAnswer = SQL.CustomerIDExists(customerID);

                                if (!customerIDAnswer)
                                {
                                    Console.WriteLine("Det intastede ID findes ikke i databasen\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Den indtastede værde er ugyldig");
                            }

                        } while (!customerIDAnswer);

                        int chooseMovie;
                        bool chooseMovieAnswer = false;
                        do
                        {
                            Console.WriteLine("Indtast film ID, på film du ønsker at booke pladser til\n");
                            string inputID = Console.ReadLine();

                            if (int.TryParse(inputID, out chooseMovie))
                            {
                                chooseMovieAnswer = SQL.MovieExists(chooseMovie);

                                if (!chooseMovieAnswer)
                                {
                                    Console.WriteLine("Det intastede ID findes ikke i databasen\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Den indtastede værde er ugyldig");
                            }

                        } while (!chooseMovieAnswer);

                        string input;
                        DateTime dateAnswer;
                        bool dateRunning = false;
                        do
                        {
                            Console.Write("Brug følgende syntax: YYYY-MM-DD HH:MM:SS\n" +
                                "Indtast dato: ");
                            input = Console.ReadLine();

                            if (DateTime.TryParse(input, out dateAnswer))
                            {
                                dateRunning = true;
                            }
                        } while (dateRunning);

                        bool seatCountRunning = false;
                        int seatCountAnswer;
                        do
                        {
                            Console.Write("Indtast ønskede antal sidepladser: ");
                            string seatCount = Console.ReadLine();

                            if (int.TryParse(input, out seatCountAnswer))
                            {
                                seatCountRunning = true;
                            }
                        } while (seatCountRunning);

                        string bType;
                        int bTypeVal;
                        do
                        {
                            Console.WriteLine("Vælg bruger type:   [0] - Online user. [1] - In store");
                            bType = Console.ReadLine();

                            if (!int.TryParse(bType, out bTypeVal))
                            {
                                Console.WriteLine("Den indtastede værde er ugyldig");
                            }
                        } while (bTypeVal != 0 && bTypeVal != 1);

                        Booking Booking = new Booking(customerID, chooseMovie, input, seatCountAnswer, (Booking.BookingTypeEnum)bTypeVal);
                        Booking.InsertIntoDB();

                        break;
                    case ConsoleKey.L:
                        int bookingVal;
                        bool bookingAnswer = false;
                        do
                        {
                            Console.WriteLine("Indtast ID på kunde du ønsker at se bookings for\n") ;
                            string inputID = Console.ReadLine();

                            if (int.TryParse(inputID, out bookingVal))
                            {
                                bookingAnswer = SQL.CustomerIDExists(bookingVal);

                                if (!bookingAnswer)
                                {
                                    Console.WriteLine("Det intastede ID findes ikke i databasen\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Den indtastede værde er ugyldig");
                            }

                        } while (!bookingAnswer);

                        Booking.CustomerBookings(bookingVal);

                        Console.WriteLine("\nTryk på en tast for at gå til hovedmenu");
                        Console.ReadKey(true);
                        Console.Clear();

                        break;
                    case ConsoleKey.Escape:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ugyldig indtastning");
                        break;
                }
            } while (running == true);
        }
    }
}
