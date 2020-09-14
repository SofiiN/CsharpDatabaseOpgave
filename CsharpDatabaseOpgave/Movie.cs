using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpDatabaseOpgave
{
    class Movie
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string PlayDateAndTime { get; set; }
        public int Duaration { get; set; }

        public Movie (string inputName, string inputPDAT, int inputDuaration)
        {
            MovieName = inputName;
            PlayDateAndTime = inputPDAT;
            Duaration = inputDuaration;
        }
        public void InsertIntoDB()
        {
            string sql = $"insert into Movies values ('{MovieName}','{PlayDateAndTime}',{Duaration})";
            try
            {
                SQL.insert(sql);
                Console.WriteLine($"{MovieName} blev oprettet i tabellen");
            }
            catch (Exception)
            {
                Console.WriteLine("Der opstod en fejl i oprettelsen, film IKKE oprettet");
            }
        }
        public static void DeleteMovie(int ID)
        {
            string sql = $"DELETE FROM Movies WHERE MovieID = {ID};";
            try
            {
                if (SQL.delete(sql))
                {
                    Console.WriteLine($"Film med ID {ID} er slettet fra databasen");
                }
                else
                {
                    Console.WriteLine($"Film med ID: {ID}, kunne ikke findes");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Der opstod en fejl i slet, film IKKE slettet");
            }
        }
        public static void SeeListOfMovie()
        {
            SQL.DisplayAllMovies("select * from Movies order by MovieID");
        }
    }
}
