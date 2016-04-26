using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDLibrary.Models;

namespace DVDLibrary
{
    public class LogicService : ILogicService
    {
        ILibraryRepository Repo;

        public LogicService()
        {
            Repo = new LibraryRepository();
        }

        public LogicService(ILibraryRepository repository)
        {
            Repo = repository;
        }

        public void Delete(int ID)
        {
            Repo.DeleteMovie(ID);
        }

        public void Create(Movie movie)
        {
            Repo.CreateMovie(movie);
        }

        public List<Movie> GetMovies()
        {
            List<Movie> movies = Repo.GetMovies();
            return movies;
        }

        public List<Borrow> GetBorrows()
        {
            List<Borrow> borrows = Repo.GetBorrows();
            return borrows;
        }

        public List<Movie> SearchDB(string searchString)
        {
            string dbString = "%" + searchString + "%";
            List<Movie> foundMovies =  Repo.SearchDB(dbString);
            return foundMovies;
        }
    }
}