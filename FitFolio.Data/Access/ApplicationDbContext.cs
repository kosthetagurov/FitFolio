using FitFolio.Data.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFolio.Data.Access
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(string connectionString)
            : base(GetOptions(connectionString))
        {
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
