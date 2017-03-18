using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject.Models;
using TermProject.Repositories;

namespace QuickTrainerProTests
{
    public class FakeProfileRepository
    {
        

        List<Profile> profiles = new List<Profile>();
        public IEnumerable<Profile> GetAllProfiles()
        {
            Profile p1 = new Profile
            {
                ProfileUser = new User { FirstName = "DF", Email = "df@fake.com" },
                imagePath = "~/df.jpg",
                Descripiton = "This is a test",
                City = "Eugene"
            };

            Profile p2 = new Profile
            {
                ProfileUser = new User { FirstName = "DF", Email = "df@fake.com" },
                imagePath = "~/df.jpg",
                Descripiton = "This is a test2",
                City = "Eugene"
            };
            return profiles;
        }

        public List<Profile> GetProfilesByCity(string city)
        {
            return (from p in profiles
                    where p.City == city
                    select p).ToList();
        }


        //public IEnumerable<ProfileSpecialty> GetAllSpecialties()
        //{
        //    return context.Relations.ToList();
        //}
    }

}
