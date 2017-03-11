using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TermProject.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using TermProject.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TermProject.Controllers
{
    public class AuthController : Controller
    { 
     private UserManager<User> userManager;
    private SignInManager<User> signInManager;

    public AuthController(UserManager<User> usrMgr, SignInManager<User> sim)
    {
        userManager = usrMgr;
        signInManager = sim;
    }

    public IActionResult Register()
    {
        return View(new RegisterViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel vm )
    {
        if (ModelState.IsValid)
        {
                User user = new User
                {
                    UserName = vm.FirstName + vm.LastName,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    Email = vm.Email,
                    
                };
                

                IdentityResult result = await userManager.CreateAsync(user, vm.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }
        // We get here either if the model state is invalid or if xreate user fails
        return View(vm);
    }
    
    public ViewResult Upload()
    {
        return View();
    }
    
    
public ViewResult Login()
    {
        return View(new LoginViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel vm)
    {
        if (ModelState.IsValid)
        {
            User user = await userManager.FindByNameAsync(vm.UserName);
            if (user != null)
            {
                await signInManager.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult result =
                        await signInManager.PasswordSignInAsync(
                            user, vm.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(nameof(LoginViewModel.UserName),
                "Invalid user or password");
        }
        return View(vm);
    }
}
}