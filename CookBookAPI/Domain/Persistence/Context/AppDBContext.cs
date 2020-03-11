using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBookAPI.Domain.Models;

namespace CookBookAPI.Domain.Persistence.Context
{
    public class AppDBContext : DbContext
    {

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Recipe
            builder.Entity<Recipe>().ToTable("Recipes");
            builder.Entity<Recipe>().HasKey(p => p.Id);
            builder.Entity<Recipe>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Recipe>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            //builder.Entity<Recipe>().HasMany(p => p.Ingredients).WithOne(p => p.Recipe).HasForeignKey(p => p.RecipeId);

            builder.Entity<Ingredients>().ToTable("Ingredients");
            builder.Entity<Ingredients>().HasKey(p => p.Id);
            builder.Entity<Ingredients>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Ingredients>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Ingredients>().Property(p => p.Quantity).IsRequired();
            builder.Entity<Ingredients>().Property(p => p.Measure).IsRequired();
        }
    }
}
