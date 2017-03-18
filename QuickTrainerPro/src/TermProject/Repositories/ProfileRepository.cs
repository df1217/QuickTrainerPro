using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject.Models;

namespace TermProject.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private ApplicationDbContext context;

        public ProfileRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Profile> GetAllProfiles()
        {
            return context.Profiles.Include(p => p.ProfileUser)
                .Include("Reviews.From");
        }

        public List<Profile> GetProfilesByCity(string city)
        
           
        {
            return (from p in context.Profiles
                    where p.City.Contains(city)
                    select p).ToList();
        }
    
    }
}
