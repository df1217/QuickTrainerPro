using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TermProject.Models
{
    public class User
    {
        //Backing variables
        private List<Review> reviews;
        private List<Connection> connections;
        private List<Message> messages;
        private List<Specialty> specialties;
        public int UserID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Review> Reviews { get { return reviews; } }
        public List<Message> Messages { get { return messages; } }
        public List<Connection> Connections { get { return connections; } }
        public List<Specialty> Specialties { get { return specialties; } }
        public string ZipCode { get; set; }
        public string Descripiton { get; set; }
        public bool IsTrainer { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsFlagged { get; set; }

    }
}
