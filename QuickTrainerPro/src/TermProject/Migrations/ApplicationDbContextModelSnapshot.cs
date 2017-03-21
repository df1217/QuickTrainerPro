using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TermProject.Repositories;

namespace TermProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TermProject.Models.Profile", b =>
                {
                    b.Property<int>("ProfileID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Descripiton");

                    b.Property<int?>("ProfileUserUserID");

                    b.Property<string>("imagePath");

                    b.HasKey("ProfileID");

                    b.HasIndex("ProfileUserUserID");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("TermProject.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<int?>("FromUserID");

                    b.Property<int?>("ProfileID");

                    b.Property<int>("Rating");

                    b.HasKey("ReviewID");

                    b.HasIndex("FromUserID");

                    b.HasIndex("ProfileID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("TermProject.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("Id");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TermProject.Models.Profile", b =>
                {
                    b.HasOne("TermProject.Models.User", "ProfileUser")
                        .WithMany()
                        .HasForeignKey("ProfileUserUserID");
                });

            modelBuilder.Entity("TermProject.Models.Review", b =>
                {
                    b.HasOne("TermProject.Models.User", "From")
                        .WithMany()
                        .HasForeignKey("FromUserID");

                    b.HasOne("TermProject.Models.Profile")
                        .WithMany("Reviews")
                        .HasForeignKey("ProfileID");
                });
        }
    }
}
