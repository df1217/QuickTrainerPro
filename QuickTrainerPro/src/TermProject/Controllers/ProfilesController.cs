using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TermProject.Repositories;
using TermProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using TermProject.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Authorization;

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
            userManager = userMgr;
            _environment = environment;
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
        [Authorize]
        [HttpGet]
        public IActionResult ProfileForm()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProfileForm(ProfileViewModel ProfileVm)
        {
            if (ModelState.IsValid)
            {


                User user = await userManager.FindByNameAsync(User.Identity.Name);
                await userManager.AddToRoleAsync(user, "TRAINER");
                Profile profile = new Models.Profile { City = ProfileVm.ProfileView.City, Descripiton = ProfileVm.ProfileView.Descripiton };
                var uploads = Path.Combine(_environment.WebRootPath);
                if (ProfileVm.File.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, ProfileVm.File.FileName), FileMode.Create))
                    {
                        await ProfileVm.File.CopyToAsync(fileStream);
                    }
                }
                // string name = HttpContext.User.Identity.Name;
                profile.ProfileUser = user;
                profile.imagePath = $"\\{ProfileVm.File.FileName}";
                profileRepo.Add(profile);

                return RedirectToAction("Index", "Profiles");
            }
            return View(ProfileVm);

        }
        
    }



}

