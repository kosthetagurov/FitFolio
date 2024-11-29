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
        public DbSet<TrainingProgram> TrainingPrograms { get; set; } = null!;
        public DbSet<TrainingProgramWorkout> TrainingProgramWorkouts { get; set; } = null!;
        public DbSet<TrainingProgramExercise> TrainingProgramExercises { get; set; } = null!;
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

            // TrainingProgramWorkout
            modelBuilder.Entity<TrainingProgramWorkout>()
                .HasOne(w => w.Program)
                .WithMany(p => p.Workouts)
                .HasForeignKey(w => w.ProgramId)
                .OnDelete(DeleteBehavior.Cascade);

            // TrainingProgramExercise
            modelBuilder.Entity<TrainingProgramExercise>()
                .HasOne(te => te.Workout)
                .WithMany(tw => tw.Exercises)
                .HasForeignKey(te => te.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TrainingProgramExercise>()
                .HasOne(te => te.Exercise)
                .WithMany()
                .HasForeignKey(te => te.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            // ActualWorkout
            modelBuilder.Entity<Workout>()
                .HasOne(aw => aw.ProgramWorkout)
                .WithMany()
                .HasForeignKey(aw => aw.ProgramWorkoutId)
                .OnDelete(DeleteBehavior.Restrict);

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
