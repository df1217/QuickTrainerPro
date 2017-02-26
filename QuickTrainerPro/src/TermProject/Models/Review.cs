using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TermProject.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public User Reviewer { get; set; }
        public User Reviewee { get; set; }
        public DateTime ReviewDate { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; }
        public bool IsFlagged { get; set; }
    }
}
