using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TermProject.Models
{
    public class ProfileSpecialty
    {
        
            public int SpecialtyID { get; set; }
            public Specialty PSpecialty { get; set; }
            public int ProfileID { get; set; }
            public Profile SProfile { get; set; }
            
        
    }
}
