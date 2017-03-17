using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject.Models;
using TermProject.Repositories;

namespace QuickTrainerProTests
{
    public class FakeSpecialtyRepository : ISpecialtyRepository
    {
        

        public IEnumerable<Specialty> GetAllSpecialties()
        {
            var specialties = new List<Specialty>();
            specialties.Add(new Specialty { Name = "swimming" });
            specialties.Add(new Specialty { Name = "yoga" });
            specialties.Add(new Specialty { Name = "strength" });
            return specialties;


        }
    }
}
