using CoderGirl;
using System;
using System.Collections.Generic;

namespace CoderGirl_Book_Project.Models
{
    public partial class Books
    {
        public Books()
        {
            BookAuthor = new HashSet<BookAuthor>();
            BooksCategory = new HashSet<BooksCategory>();
            BooksRating = new HashSet<BooksRating>();
            BooksTags = new HashSet<BooksTags>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Cover { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BookAuthor> BookAuthor { get; set; }
        public virtual ICollection<BooksCategory> BooksCategory { get; set; }
        public virtual ICollection<BooksRating> BooksRating { get; set; }
        public virtual ICollection<BooksTags> BooksTags { get; set; }
    }
}
