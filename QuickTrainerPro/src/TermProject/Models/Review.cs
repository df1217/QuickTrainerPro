using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TermProject.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
     
        public User From { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 20)]
        public string Body { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
       
    }
}
