using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject.Models;

namespace TermProject.Repositories
{
    public class SeedData
    {
        public static async Task EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            // Add a user for testing
            string firstName = "DF";
            string lastName = "Frank";
            string username = $"{firstName}{lastName}";
            string email = "df@fake.com";
            string password = "Test123!";
            string role = "Admin";

            UserManager<User> userManager = app.ApplicationServices.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();

            if (!context.Profiles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = "Member" });
                await roleManager.CreateAsync(new IdentityRole() { Name = "Trainer" });

                User user = await userManager.FindByNameAsync(username);
                if (user == null)
                {
                    user = new User { FirstName = firstName, LastName = lastName, UserName = username, Email = email };
                    IdentityResult result = await userManager.CreateAsync(user, password);
                    //if (await roleManager.FindByNameAsync(role) == null)
                    //{
                        IdentityResult resultCreate = await roleManager.CreateAsync(new IdentityRole(role));
                        if (resultCreate.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, role.ToUpper());
                        }
                    //}
                }

                

                Profile profile = new Profile
                {
                    ProfileUser = user,
                    imagePath = "/df.jpg",
                    Descripiton = "This is a test",
                    City = "Eugene"
                    
                };

                context.Profiles.Add(profile);
                Review review = new Review
                {
                    From = user,
                    Body = "This is a test",
                    Rating = 5
                };
                 profile = new Profile
                {
                    ProfileUser = user,
                    imagePath = "/df.jpg",
                    Descripiton = "This is a test2",
                    City = "Eugene",
                    
                };
                profile.Reviews.Add(review);
                context.Profiles.Add(profile);

                

                context.SaveChanges();
            }
        }
    }
}

