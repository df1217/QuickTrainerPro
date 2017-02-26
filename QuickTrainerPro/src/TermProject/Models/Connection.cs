using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TermProject.Models
{
    public class Connection
    {
        public int ConnectionID { get; set; }
        public User Connector { get; set; }
        public User Connectee { get; set; }

        public DateTime ConnectionDate { get; set; }
       
    }
}
