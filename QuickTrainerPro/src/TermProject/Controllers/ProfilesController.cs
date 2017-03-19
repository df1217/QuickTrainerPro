using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TermProject.Repositories;
using TermProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TermProject.Controllers
{
    public class ProfilesController : Controller
    {
        private IHostingEnvironment _environment;

        private IProfileRepository profileRepo;
        private UserManager<User> userManager;


        public ProfilesController(IProfileRepository repo, UserManager<User> userMgr, IHostingEnvironment environment)
        { 
            profileRepo = repo;
            userMgr = userManager;
            environment = _environment;
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

        public IActionResult ProfilesByCity(string city)
        {
            ViewBag.City = city ;
            return View(profileRepo.GetProfilesByCity(city).ToList());
        }

        [HttpGet]
        public IActionResult ProfileForm()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> ProfileForm([Bind("City", "Descripiton")]Profile profile)
        {
            User user = await userManager.FindByNameAsync(User.Identity.Name);

            // string name = HttpContext.User.Identity.Name;
            profile.ProfileUser = user;
            profileRepo.Add(profile);
            
            return RedirectToAction("Index", "Profiles");

        }
        
    }



}

