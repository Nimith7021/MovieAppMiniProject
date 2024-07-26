using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using MovieLibrary.Exceptions;
using MovieLibrary.Repository;

namespace MovieApplication.Controllers
{
    internal class MovieStore
    {
        public static void DisplayMovieMenu()
        {
            MovieManager.ManageMovies();
            while (true)
            {
                Console.WriteLine("\nWelcome to the Movie Store Developed by :Nimith\n" +
                    "What do you wish to do ?\n" +
                    "1 . Add new Movie \n" +
                    "2 . Display All Movies \n" +
                    "3 . Find Movie By Id \n" +
                    "4 . Remove Movie by Id \n" +
                    "5 . Clear All Movies \n" +
                    "6 . Exit");

                Console.WriteLine("Enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                try
                {
                    DoTask(choice);
                }
                catch (MovieNotFoundException mnf)
                {
                    Console.WriteLine(mnf.Message);
                }
                catch (CapacityFullException cfe)
                {
                    Console.WriteLine(cfe.Message);
                }
                catch (MovieStoreEmptyException mse)
                {
                    Console.WriteLine(mse.Message);
                }
                catch(MovieNameLengthExceedException mle)
                {
                    Console.WriteLine(mle.Message);
                }
                catch(MovieNotInRangeException mre)
                {
                    Console.WriteLine(mre.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void DoTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    
                    Add();
                    break;

                case 2:
                    Display();
                    break;

                case 3:
                    Find();
                    break;

                case 4:
                    Remove();
                    break;

                case 5:
                    MovieManager.ClearAllMovies();
                    Console.WriteLine("Movies cleared Successfully");
                    break;

                case 6:
                    MovieManager.ExitAccount();
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Please enter a valid choice");
                    break;
            }
        }

        public static void Add()
        {
            int id = 0;
            try
            {
                Console.WriteLine("Enter your Movie Id");
                id = Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException)
            {
                throw new FormatException("Not in Proper Format");
            }

            Console.WriteLine("Enter your Movie Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your Movie Genre ");
            string genre = Console.ReadLine();
            Console.WriteLine("Enter the year of release");
            int year = Convert.ToInt32(Console.ReadLine());
            
            MovieManager.AddNewMovie(id, name, genre, year);
            Console.WriteLine("Movie Added Successfully");
        }

        public static void Display()
        {
            var movies = MovieManager.DisplayMovies();
            movies.ForEach(movie => Console.WriteLine(movie));
        }

        public static void Find()
        {
            Console.WriteLine("Enter your Movie Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            var movie = MovieManager.FindMovieById(id);
            Console.WriteLine(movie);
        }

        public static void Remove()
        {
            Console.WriteLine("Enter your Movie Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            MovieManager.RemoveMovieById(id);
            Console.WriteLine("Movie Removed Successfully");

        }

        
    }
}
