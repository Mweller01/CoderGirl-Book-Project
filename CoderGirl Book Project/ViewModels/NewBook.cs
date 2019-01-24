using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_Book_Project.ViewModels
{
    public class NewBook
{
        //book model
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Cover { get; set; }
        public string Description { get; set; }

        //author model
        public string Author { get; set; }

        //category
        public string Category { get; set; }

        //rating
        public string Rating { get; set; }

        //tags
        public string Tag { get; set; }
    }
}
