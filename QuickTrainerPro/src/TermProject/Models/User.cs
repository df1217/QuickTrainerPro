using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TermProject.Models
{
    public class User : IdentityUser
    {
       
       
        private List<Specialty> specialties = new List<Specialty>();
       // private List<Message> messages = new List<Message>();
        //private List<Review> reviews = new List<Review>();
       
        public string FName { get; set; }
        public string LName { get; set; }
       // public List<Specialty> Specialties { get { return specialties; } }
       // public List<Message> Messages { get { return messages; } }
       // public List<Review> Reviews { get { return reviews; } }

        public byte[]  Media { get; set; }
        public string ZipCode { get; set; }
        public string Descripiton { get; set; }
        
    }
}
