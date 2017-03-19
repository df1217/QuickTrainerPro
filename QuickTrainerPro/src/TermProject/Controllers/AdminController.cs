using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TermProject.Repositories;
using TermProject.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TermProject.Controllers
{
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
            return View();
        }

        public IActionResult ShowAllReviews()
        {
            return View(reviewRepo.GetAllReviews().ToList());
        }


    }
}
