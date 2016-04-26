using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDLibrary.Models;


namespace DVDLibrary
{
    public interface ILogicService
    {
        void Delete(int ID);
        void Create(Movie movie);
        List<Movie> GetMovies();
        List<Borrow> GetBorrows();
        List<Movie> SearchDB(string searchString);
    }
}