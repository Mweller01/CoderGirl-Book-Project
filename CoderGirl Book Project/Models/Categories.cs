using System;
using System.Collections.Generic;

namespace CoderGirl_Book_Project.Models
{
    public partial class Categories
    {
        public Categories()
        {
            BooksCategory = new HashSet<BooksCategory>();
        }

        public int Id { get; set; }
        public string Category { get; set; }

        public virtual ICollection<BooksCategory> BooksCategory { get; set; }
    }
}
