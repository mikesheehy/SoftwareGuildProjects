using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDLibrary.Models;

namespace DVDLibrary.Repositiories
{
    public class FakeRepository : ILibraryRepository
    {
        #region fake data
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

        #endregion

        public void CreateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovie(int ID)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}