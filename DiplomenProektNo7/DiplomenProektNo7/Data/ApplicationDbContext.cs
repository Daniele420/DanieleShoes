using DiplomenProektNo7.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DiplomenProektNo7.Models.Shoe;
using DiplomenProektNo7.Models.Order;

namespace DiplomenProektNo7.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DiplomenProektNo7.Models.Shoe.ShoeCreateVM> ShoeCreateVM { get; set; }
        public DbSet<DiplomenProektNo7.Models.Shoe.ShoeIndexVM> ShoeIndexVM { get; set; }
        public DbSet<DiplomenProektNo7.Models.Shoe.ShoeEditVM> ShoeEditVM { get; set; }
        public DbSet<DiplomenProektNo7.Models.Shoe.ShoeDetailsVM> ShoeDetailsVM { get; set; }
        public DbSet<DiplomenProektNo7.Models.Shoe.ShoeDeleteVM> ShoeDeleteVM { get; set; }
        public DbSet<DiplomenProektNo7.Models.Order.OrderConfirmVM> OrderConfirmVM { get; set; }
    }
}
