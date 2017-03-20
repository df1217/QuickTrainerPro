using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TermProject.Repositories;
using TermProject.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TermProject.Controllers
{
    [Authorize(Roles = "Admin, Trainers")]
    public class AdminController : Controller
    {

       
        private IProfileRepository profileRepo;
        private IReviewRepository reviewRepo;
        private UserManager<User> userManager;

        public AdminController(IProfileRepository repo, IReviewRepository rRepo, UserManager<User> userMg)
        {
            profileRepo = repo;
            reviewRepo = rRepo;
            userManager = userMg;
        }
        public IActionResult Index()
        {
            return View(profileRepo.GetAllProfiles().ToList()); 
        }

        public IActionResult ShowAllReviews()
        {
            return View(reviewRepo.GetAllReviews().ToList());
        }

        public IActionResult Delete(int id)
        {
            var deleted = reviewRepo.DeleteReviewByProfile(id);
            var profile = profileRepo.DeleteProfile(id);
            return RedirectToAction("Index", "Admin");
        }


    }
}
