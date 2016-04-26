using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLibrary.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public DateTime Release { get; set; }
        public string MPAA { get; set; }
        public string Director { get; set; }
        public string Studio { get; set; }
        public int LibRating { get; set; }
        public string LibNotes { get; set; }
    }
}