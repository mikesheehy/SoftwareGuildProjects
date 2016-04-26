using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLibrary.Models
{
    public class Borrow
    {
        public string Title { get; set; }

        public string Borrower { get; set; }
        public DateTime CheckedOut { get; set; }
        public DateTime? CheckedIn { get; set; }
        public string BorrowedNote { get; set; }
        public double? BorrowRating { get; set; }
    }
}