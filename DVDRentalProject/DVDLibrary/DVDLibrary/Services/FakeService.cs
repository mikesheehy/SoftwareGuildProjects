using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDLibrary.Models;

namespace DVDLibrary.Services
{
    public class FakeService : ILogicService
    {
        public static List<Movie> MoviesMaster = new List<Movie>()
        {
            new Movie
            {
                MovieID = 1,
                Title = "Jurassic Park",
                Director = "Steven Spielberg"
            },
            new Movie
            {
                MovieID = 2,
                Title = "Titanic",
                Director = "James Cameron"
            }
        };

        public static List<Borrow> BorrowsMaster = new List<Borrow>()
        {
            new Borrow
            {
                Title = "Jurassic Park",
                Borrower = "Alex",
                CheckedOut = new DateTime(2016, 04, 02),
            },
            new Borrow
            {
                Title = "Titanic",
                Borrower = "Alex",
                CheckedOut = new DateTime(2016, 04, 06),
            }
        };

        public void Create(Movie movie)
        {
            MoviesMaster.Add(movie);
        }

        public void Delete(int ID)
        {
            MoviesMaster.Remove(MoviesMaster[1]);
        }

        public List<Borrow> GetBorrows()
        {
            return BorrowsMaster;
        }

        public List<Movie> GetMovies()
        {
            return MoviesMaster;
        }

        public List<Movie> SearchDB(string searchString)
        {
            List<Movie> movies = new List<Movie>()
            {
                new Movie
                {
                    Title = "Home Alone"
                },
                new Movie
                {
                    Title = "Home Alone 2: Lost in New York"
                }
            };

            return movies;
        }
    }
}