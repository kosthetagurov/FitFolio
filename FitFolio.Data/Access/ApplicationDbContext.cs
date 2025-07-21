using FitFolio.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FitFolio.Data.Access
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
            
        }

        public DbSet<Exercise> Exercises { get; set; } = null!;
        public DbSet<ExerciseCategory> ExerciseCategories { get; set; } = null!;
        public DbSet<Workout> Workouts { get; set; } = null!;
        public DbSet<WorkoutDetail> WorkoutDetails { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Exercise
            modelBuilder.Entity<Exercise>()
                .HasOne(e => e.Category)
                .WithMany(c => c.Exercises)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // ActualWorkoutExercise
            modelBuilder.Entity<WorkoutDetail>()
                .HasOne(awe => awe.Workout)
                .WithMany(aw => aw.Details)
                .HasForeignKey(awe => awe.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WorkoutDetail>()
                .HasOne(awe => awe.Exercise)
                .WithMany()
                .HasForeignKey(awe => awe.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
