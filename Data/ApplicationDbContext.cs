using EgyptBYU.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace EgyptBYU.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MummyEntity> mummy { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Change data type for TwoFactorEnabled to tinyint
            builder
                .Entity<IdentityUser>()
                .Property(u => u.TwoFactorEnabled)
                .HasColumnType("tinyint");
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    // Create a custom value converter for bool to tinyint
        //    var boolConverter = new BoolToZeroOneConverter<short>();

        //    // Register the value converter with Entity Framework Core
        //    builder
        //        .Entity<IdentityUser>()
        //        .Property(u => u.TwoFactorEnabled)
        //        .HasConversion(boolConverter);
        //}
    }
}
