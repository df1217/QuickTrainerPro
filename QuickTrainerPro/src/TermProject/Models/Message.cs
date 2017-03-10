using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TermProject.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public string Subject { get; set; }
        public DateTime MessageTime { get; set; }
        public User To { get; set; }
        public User From { get; set; }
        public string Body { get; set; }
    }
}
