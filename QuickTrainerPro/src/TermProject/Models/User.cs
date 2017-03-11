using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TermProject.Models
{
    public class User : IdentityUser
    {
       
       
             
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        
    }
}
