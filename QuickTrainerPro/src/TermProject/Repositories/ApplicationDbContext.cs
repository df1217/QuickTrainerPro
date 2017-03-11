﻿using Microsoft.EntityFrameworkCore;
using TermProject.Models;

namespace TermProject.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Specialty> Specialties { get; set; }

        public DbSet<Profile> Profiles { get; set; }
    }
}
