using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TermProject.Models
{
    public class Profile
    {
        private List<Review> reviews = new List<Review>();
       // private List<Specialty> specialties = new List<Specialty>();
       
        public int ProfileID { get; set; }
        public User ProfileUser { get; set; }

        public string imagePath { get; set; }
        public string City { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 20)]
        public string Descripiton { get; set; }

        public List<Review> Reviews { get { return reviews; } }

       


    }
}
