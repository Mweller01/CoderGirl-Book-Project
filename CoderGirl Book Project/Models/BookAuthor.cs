using System;
using System.Collections.Generic;

namespace CoderGirl_Book_Project.Models
{
    public partial class BookAuthor
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Books Book { get; set; }
    }
}
