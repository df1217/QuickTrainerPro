using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TermProject.Models
{
    public class User : IdentityUser
    {


        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        
    }
}
