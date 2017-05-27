using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TermProject.Repositories;
using Microsoft.AspNetCore.Identity;
using TermProject.Models;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TermProject.Controllers
{
    public class ReviewController : Controller
    {
        private IProfileRepository profileRepo;
        private IReviewRepository reviewRepo;
        private UserManager<User> userManager;
        

        public ReviewController(UserManager<User> userMgr, IProfileRepository repo)
        {
            profileRepo = repo;
            userManager = userMgr;
        }
        [Authorize]
        [HttpGet]
        public ViewResult ReviewForm(int id)
        {
            var reviewVm = new ReviewViewModel();
            reviewVm.ProfileID = id;
            reviewVm.ProfileReview = new Review();
            

            return View(reviewVm);
        }


        [HttpPost]
        public async Task<IActionResult> ReviewForm(ReviewViewModel reviewVm)
        {
            string body = reviewVm.ProfileReview.Body;
            if (string.IsNullOrEmpty(body))
            {
                
                string prop = "ProfileReview.Body";
                ModelState.AddModelError(prop, "Please enter at least two words");
            }


            if (ModelState.IsValid)
            {
                // Get the full model object for the book being reviewed
                Profile profile = (from p in profileRepo.GetAllProfiles()
                             where p.ProfileID == reviewVm.ProfileID
                             select p).FirstOrDefault<Profile>();

                // add the review and save the book object to the db
                Review review = new Review { Body = reviewVm.ProfileReview.Body, Rating = reviewVm.ProfileReview.Rating };
                string name = HttpContext.User.Identity.Name;
                review.From = await userManager.FindByNameAsync(name);
                

                profile.Reviews.Add(review);
                profileRepo.Update(profile);

                return RedirectToAction("Index", "Profiles");
            }
            else
            {
                return View(reviewVm);
            }
        }

    }
}

