﻿using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(255)]
        public string DrivingLicense { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
          //  this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(c => c.FirstName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Customer>().Property(c => c.LastName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Customer>().Property(c => c.BirthDate).IsOptional();

            modelBuilder.Entity<Movie>().Property(c => c.Name).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Movie>().Property(c => c.DateAdded).IsRequired();
            modelBuilder.Entity<Movie>().Property(c => c.NumberInStock).IsRequired();
            modelBuilder.Entity<Movie>().HasRequired(m => m.Genre);

            modelBuilder.Entity<MembershipType>().Property(t => t.Name).IsRequired().HasMaxLength(255);

            modelBuilder.Entity<Genre>().Property(g => g.Name).IsRequired().HasMaxLength(255);

            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}