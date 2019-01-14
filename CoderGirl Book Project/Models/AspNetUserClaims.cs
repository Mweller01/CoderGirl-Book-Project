using System;
using System.Collections.Generic;

namespace CoderGirl_Book_Project.Models
{
    public partial class AspNetUserClaims
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
