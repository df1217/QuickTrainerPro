using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject.Models;

namespace TermProject.ViewModels
{
    public class ProfileViewModel
    {
        public IFormFile File { get; set; }
        public Profile ProfileView { get; set; }
    }
}
