using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TermProject.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TermProject.Controllers
{
    public class HomeController : Controller
    {
        private ISpecialtyRepository specialtyRepo;

        public HomeController(ISpecialtyRepository repo)
        {
            specialtyRepo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Home/About/")]
        public IActionResult About()
        {
            return View();
        }
        [HttpGet("Home/About/Contact/")]
        public IActionResult Contact()
        {
            return View();
        }

        public ViewResult Specialties()
        {
            var specialties = specialtyRepo.GetAllSpecialties().ToList();
            return View(specialties);
        }
    }
}
