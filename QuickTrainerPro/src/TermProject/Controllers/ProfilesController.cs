using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TermProject.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TermProject.Controllers
{
    public class ProfilesController : Controller
    {
        private IProfileRepository profileRepo;

        public ProfilesController(IProfileRepository repo)
        {
            profileRepo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Profiles/Profile/")]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
