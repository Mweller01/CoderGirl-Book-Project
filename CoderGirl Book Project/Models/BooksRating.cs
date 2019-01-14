using CoderGirl;
using System;
using System.Collections.Generic;

namespace CoderGirl_Book_Project.Models
{
    public partial class BooksRating
    {
        public int BookId { get; set; }
        public int RatingId { get; set; }

        public virtual Books Book { get; set; }
        public virtual Ratings Rating { get; set; }
    }
}
