using System;
using System.Collections.Generic;

namespace CoderGirl_Book_Project.Models
{
    public partial class Ratings
    {
        public Ratings()
        {
            BooksRating = new HashSet<BooksRating>();
        }

        public int Id { get; set; }
        public string Rating { get; set; }

        public virtual ICollection<BooksRating> BooksRating { get; set; }
    }
}
