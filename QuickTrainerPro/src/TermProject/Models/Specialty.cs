using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TermProject.Models
{
    public class Specialty
    {
        public int SpecialtyID { get; set; }
        public string Name { get; set; }

        public List<ProfileSpecialty> PSpecialties { get; set; }

    }
}
