using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject.Models;

namespace TermProject.Repositories
{
    
    
        public class AppIdentityDbContext : IdentityDbContext<User>
        {
            public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options) { }
        }
    }

