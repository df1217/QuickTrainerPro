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
                    select p).Include(p => p.ProfileUser)
                .Include("Reviews.From").ToList();
        }



        public int Update(Profile profile)
        {
            context.Profiles.Update(profile);
            return context.SaveChanges();
        }

        public int Add(Profile profile)
        {
            context.Profiles.Add(profile);
            return context.SaveChanges();
        }

        public Profile DeleteProfile(int profileID)
        {
            Profile dProfile = context.Profiles
                .FirstOrDefault(m => m.ProfileID == profileID);
            if (dProfile != null)
            {
                context.Profiles.Remove(dProfile);
                context.SaveChanges();
            }
            return dProfile;
        }

    }
}
