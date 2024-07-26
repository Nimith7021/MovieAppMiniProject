using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }

        public int YearOfRelease { get; set; }

        public Movie()
        {

        }

        public Movie(int id , string name , string genre , int year)
        {
            Id = id;
            Name = name;
            Genre = genre;
            YearOfRelease = year;
        }

        public static Movie CreateNewMovieEntry(int id , string name , string Genre , int year)
        {
            return new Movie(id,name,Genre,year);
        }

        public override string ToString()
        {
            Console.WriteLine($"=================Movie Id : {Id}========================");
            return $"Movie Id : {Id}\n" +
                $"Movie Name : {Name}\n" +
                $"Movie Genre {Genre}\n" +
                $"Movie's Year Of Release : {YearOfRelease}\n";
        }


    }
    }

