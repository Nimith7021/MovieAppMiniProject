using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary.Exceptions;
using MovieLibrary.Models;
using MovieLibrary.Services;

namespace MovieLibrary.Repository
{
    public class MovieManager
    {
        static List<Movie> movies = new List<Movie>();

        public static void ManageMovies() {

            movies = DataSerializer.MovieDeserialize();
        }

        public static void AddNewMovie(int id,string name,string genre,int year)
        {
            if (movies.Count >= 5)
            {
                throw new CapacityFullException("Capacity exceeded ! Cant add movies");

            }
            else
            {
                if (name.Length > 15)
                    throw new MovieNameLengthExceedException("Movie Name Length exceeds");
                if (year <= 1996 || year >= 2024)
                    throw new MovieNotInRangeException("Movie not in specified year range");

                Movie movie = Movie.CreateNewMovieEntry(id, name, genre, year);
                movies.Add(movie);
            }
        }

      

        public static void ExitAccount()
        {
           DataSerializer.MovieSerialize(movies);
        }

        public static List<Movie> DisplayMovies()
        {
            if (movies.Count == 0)
                throw new MovieStoreEmptyException
                    ("Nothing to Display as there are no movies in List !!!");
            else
                return movies;
        }


        public static Movie FindMovieById(int id)
        {
            Movie findMovie = null;
            
            findMovie = movies.Where(item => item.Id == id).FirstOrDefault();
            if (findMovie != null)
                return findMovie;
            else
                throw new MovieNotFoundException("Movie does not exist in the List");

        }

        public static void RemoveMovieById(int id)
        {
            Movie findMovie = FindMovieById(id);
            if (findMovie == null)
                throw new MovieNotFoundException("Movie does not exist");
            else
            {
                movies.Remove(findMovie);
            }
        }

        public static void ClearAllMovies()
        {
            if (movies.Count == 0)
                throw new MovieStoreEmptyException
                    ("Nothing to Clear as there are no movies in List !!!");
            else
                movies.Clear();
            
        }


    }
}
