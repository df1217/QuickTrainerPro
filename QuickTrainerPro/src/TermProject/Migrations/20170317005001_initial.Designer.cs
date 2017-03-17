using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TermProject.Repositories;

namespace TermProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170317005001_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TermProject.Models.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<string>("FromId");

                    b.Property<DateTime>("MessageTime");

                    b.Property<int?>("ProfileID");

                    b.Property<string>("Subject");

                    b.Property<string>("ToId");

                    b.HasKey("MessageID");

                    b.HasIndex("FromId");

                    b.HasIndex("ProfileID");

                    b.HasIndex("ToId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("TermProject.Models.Profile", b =>
                {
                    b.Property<int>("ProfileID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripiton");

                    b.Property<byte[]>("ProfileImg");

                    b.Property<string>("ProfileUserId");

                    b.Property<string>("ZipCode");

                    b.HasKey("ProfileID");

                    b.HasIndex("ProfileUserId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("TermProject.Models.ProfileSpecialty", b =>
                {
                    b.Property<int>("SpecialtyID");

                    b.Property<int>("ProfileID");

                    b.HasKey("SpecialtyID", "ProfileID");

                    b.HasIndex("ProfileID");

                    b.ToTable("ProfileSpecialty");
                });

            modelBuilder.Entity("TermProject.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<string>("FromId");

                    b.Property<int?>("ProfileID");

                    b.Property<int>("Rating");

                    b.Property<DateTime>("ReviewDate");

                    b.Property<string>("ToId");

                    b.HasKey("ReviewID");

                    b.HasIndex("FromId");

                    b.HasIndex("ProfileID");

                    b.HasIndex("ToId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("TermProject.Models.Specialty", b =>
                {
                    b.Property<int>("SpecialtyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("SpecialtyID");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("TermProject.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

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

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TermProject.Models.Message", b =>
                {
                    b.HasOne("TermProject.Models.User", "From")
                        .WithMany()
                        .HasForeignKey("FromId");

                    b.HasOne("TermProject.Models.Profile")
                        .WithMany("Messages")
                        .HasForeignKey("ProfileID");

                    b.HasOne("TermProject.Models.User", "To")
                        .WithMany()
                        .HasForeignKey("ToId");
                });

            modelBuilder.Entity("TermProject.Models.Profile", b =>
                {
                    b.HasOne("TermProject.Models.User", "ProfileUser")
                        .WithMany()
                        .HasForeignKey("ProfileUserId");
                });

            modelBuilder.Entity("TermProject.Models.ProfileSpecialty", b =>
                {
                    b.HasOne("TermProject.Models.Profile", "SProfile")
                        .WithMany("PSpecialties")
                        .HasForeignKey("ProfileID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TermProject.Models.Specialty", "PSpecialty")
                        .WithMany("PSpecialties")
                        .HasForeignKey("SpecialtyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TermProject.Models.Review", b =>
                {
                    b.HasOne("TermProject.Models.User", "From")
                        .WithMany()
                        .HasForeignKey("FromId");

                    b.HasOne("TermProject.Models.Profile")
                        .WithMany("Reviews")
                        .HasForeignKey("ProfileID");

                    b.HasOne("TermProject.Models.User", "To")
                        .WithMany()
                        .HasForeignKey("ToId");
                });
        }
    }
}
