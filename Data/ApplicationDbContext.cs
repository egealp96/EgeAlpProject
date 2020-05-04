using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EgeAlpProject.Models;


namespace EgeAlpProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {



        public DbSet<Car> Cars { get; set; }

        public DbSet<CarBrand> CarBrands { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Rental> Rentals { get; set; }

        public DbSet<CarImage> CarImages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        { }

    }
}
