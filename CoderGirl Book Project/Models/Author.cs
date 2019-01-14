using CoderGirl;
using System;
using System.Collections.Generic;

namespace CoderGirl_Book_Project.Models
{
    public partial class Author
    {
        public Author()
        {
            BookAuthor = new HashSet<BookAuthor>();
        }

        public int Id { get; set; }
        public string Author1 { get; set; }

        public virtual ICollection<BookAuthor> BookAuthor { get; set; }
    }
}
