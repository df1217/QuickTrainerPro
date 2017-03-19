using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TermProject.Models
{
    public class User : IdentityUser
    {


        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static implicit operator User(Profile v)
        {
            throw new NotImplementedException();
        }
    }
}
