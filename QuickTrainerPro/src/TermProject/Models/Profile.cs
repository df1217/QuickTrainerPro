using System.Collections.Generic;

namespace TermProject.Models
{
    public class Profile
    {
        private List<Review> reviews = new List<Review>();
       // private List<Specialty> specialties = new List<Specialty>();
        private List<Message> messages = new List<Message>();
        public int ProfileID { get; set; }
        public User ProfileUser { get; set; }
        public byte[] ProfileImg { get; set; }
        public string ZipCode { get; set; }
        public string Descripiton { get; set; }

        public List<Review> Reviews { get { return reviews; } }
        public List<Message> Messages { get { return messages; } }

        public List<ProfileSpecialty> PSpecialties { get; set; }


    }
}
