using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityUser<string>>();
            modelBuilder.Entity<ProfileSpecialty>()
                .HasKey(s => new { s.SpecialtyID, s.ProfileID });

            modelBuilder.Entity<ProfileSpecialty>()
                .HasOne(ps => ps.SProfile)
                .WithMany(p => p.PSpecialties)
                .HasForeignKey(ps => ps.ProfileID);

            modelBuilder.Entity<ProfileSpecialty>()
                .HasOne(ps => ps.PSpecialty)
                .WithMany(s => s.PSpecialties )
                .HasForeignKey(ps => ps.SpecialtyID);

        }

       
    }
}
