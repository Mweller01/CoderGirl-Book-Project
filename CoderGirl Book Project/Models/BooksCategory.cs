using CoderGirl;
using System;
using System.Collections.Generic;

namespace CoderGirl_Book_Project.Models
{
    public partial class BooksCategory
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }

        public virtual Books Book { get; set; }
        public virtual Categories Category { get; set; }
    }
}
