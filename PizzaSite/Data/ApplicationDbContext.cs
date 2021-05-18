using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaSite.Models;

namespace PizzaSite.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
       
        public DbSet<User> UsersInformation { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Salad> Salads { get; set; }
        public DbSet<Drinks> Drinks { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
