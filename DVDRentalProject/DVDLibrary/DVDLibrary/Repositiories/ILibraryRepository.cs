using System.Collections.Generic;
using DVDLibrary.Models;

namespace DVDLibrary
{
    public interface ILibraryRepository
    {
        void CreateMovie(Movie movie);
        void DeleteMovie(int ID);
        List<Borrow> GetBorrows();
        List<Movie> GetMovies();
        List<Movie> SearchDB(string searchString);
    }
}