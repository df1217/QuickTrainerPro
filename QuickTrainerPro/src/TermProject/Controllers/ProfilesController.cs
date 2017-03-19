using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TermProject.Repositories;
using TermProject.Models;

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
            ViewBag.City = "Oregon";
            return View(profileRepo.GetAllProfiles().ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = profileRepo.GetAllProfiles().SingleOrDefault(p => p.ProfileID == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }
    }
}
