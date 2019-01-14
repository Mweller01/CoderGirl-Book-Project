using System;
using System.Collections.Generic;

namespace CoderGirl_Book_Project.Models
{
    public partial class Tags
    {
        public Tags()
        {
            BooksTags = new HashSet<BooksTags>();
        }

        public int Id { get; set; }
        public string Tag { get; set; }

        public virtual ICollection<BooksTags> BooksTags { get; set; }
    }
}
