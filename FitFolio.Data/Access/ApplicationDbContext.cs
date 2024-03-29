﻿using FitFolio.Data.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFolio.Data.Access
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(string connectionString)
            : base(GetOptions(connectionString))
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ExerciseCategory>()
                .HasMany(x => x.Exercises)
                .WithOne(x => x.ExerciseCategory)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Workout>()
                .HasMany(x => x.WorkoutDetails)
                .WithOne(x => x.Workout)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return NpgsqlDbContextOptionsBuilderExtensions.UseNpgsql(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseCategory> ExerciseCategories { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutDetail> WorkoutDetails { get; set; }
    }
}
