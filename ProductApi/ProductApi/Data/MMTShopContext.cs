﻿using Microsoft.EntityFrameworkCore;
using ProductApiLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Data
{
    public class MMTShopContext : DbContext
    {
        public MMTShopContext(DbContextOptions<MMTShopContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<FeaturedProductRange> FeaturedProductRanges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<FeaturedProductRange>().ToTable("FeaturedProductRange");
        }
    }
}
