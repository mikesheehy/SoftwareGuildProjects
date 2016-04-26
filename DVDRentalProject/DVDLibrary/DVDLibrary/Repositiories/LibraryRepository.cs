using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using DVDLibrary.Models;

namespace DVDLibrary
{
    public class LibraryRepository : ILibraryRepository
    {
        private string connectionString;

        public LibraryRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "Select * from MovieList";
                cmd.Connection = cn;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Movie movie = new Movie();
                        movie.Title = dr["Title"].ToString();
                        movie.MovieID = (int)dr["MovieID"];
                        movie.Release = (DateTime)dr["ReleaseDate"];
                        movie.MPAA = dr["MPAARating"].ToString();
                        movie.Director = dr["DirectorName"].ToString();
                        movie.Studio = dr["Studio"].ToString();
                        movie.LibRating = (int)dr["UserRating"];
                        movie.LibNotes = dr["UserNote"].ToString();

                        movies.Add(movie);
                    }
                }
            }

            return movies;
        }

        public void CreateMovie(Movie movie)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "AddMovieRow"; //proc name
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@ReleaseDate", movie.Release);
                cmd.Parameters.AddWithValue("@MPAARating", movie.MPAA);
                cmd.Parameters.AddWithValue("@DirectorName", movie.Director);
                cmd.Parameters.AddWithValue("@Studio", movie.Studio);
                cmd.Parameters.AddWithValue("@UserRating", movie.LibRating);
                cmd.Parameters.AddWithValue("@UserNote", movie.LibNotes);
                cmd.Connection = cn;

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteMovie(int ID)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "DeleteMovieRow"; //SProc namecmd.
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MovieID", ID);
                cmd.Connection = cn;

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<Borrow> GetBorrows()
        {
            List<Borrow> borrows = new List<Borrow>();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "allmovieborrowhistory"; //SProc name
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Borrow borrow = new Borrow();
                        borrow.Title = dr["Title"].ToString();
                        borrow.Borrower = dr["BorrowName"].ToString();
                        borrow.CheckedOut = (DateTime)dr["DateBorrowed"];
                        if (dr["DateReturned"] == DBNull.Value)
                        {
                            borrow.CheckedIn = null;
                            borrow.BorrowRating = null;
                            //borrow.BorrowedNote = null;
                        }
                        else
                        {
                            borrow.CheckedIn = (DateTime)dr["DateReturned"];
                            borrow.BorrowRating = (int)dr["Rating"];
                            //borrow.BorrowedNote = dr["BorrowNote"].ToString();
                        }

                        borrows.Add(borrow);
                    }
                }
            }
            return borrows;
        }

        public List<Movie> SearchDB(string searchString)
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "searchbytitle"; //search SProc name
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", searchString);
                cmd.Connection = cn;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Movie movie = new Movie();
                        movie.Title = dr["Title"].ToString();
                        movie.MovieID = (int)dr["MovieID"];
                        movie.Release = (DateTime)dr["ReleaseDate"];
                        movie.MPAA = dr["MPAARating"].ToString();
                        movie.Director = dr["DirectorName"].ToString();
                        movie.Studio = dr["Studio"].ToString();
                        movie.LibRating = (int)dr["UserRating"];
                        movie.LibNotes = dr["UserNote"].ToString();

                        movies.Add(movie);
                    }
                }
            }
            return movies;
        }

    }
}