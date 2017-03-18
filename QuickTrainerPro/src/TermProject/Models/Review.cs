using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TermProject.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
     
        public User From { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; }
       
    }
}
