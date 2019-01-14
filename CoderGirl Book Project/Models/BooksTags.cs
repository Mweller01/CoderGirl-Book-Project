using CoderGirl;
using System;
using System.Collections.Generic;

namespace CoderGirl_Book_Project.Models
{
    public partial class BooksTags
    {
        public int BookId { get; set; }
        public int TagId { get; set; }

        public virtual Books Book { get; set; }
        public virtual Tags Tag { get; set; }
    }
}
