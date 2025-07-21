using System.ComponentModel.DataAnnotations.Schema;

namespace FitFolio.Data.Models
{
    [Obsolete(error: true, message: "Not used")]
    public class TrainingProgramExercise
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid WorkoutId { get; set; }
        public Guid ExerciseId { get; set; }
        public int Order { get; set; }
        public int? Sets { get; set; }
        public int? Repetitions { get; set; }
        public float? Weight { get; set; }
        public int? Duration { get; set; }

        public TrainingProgramWorkout Workout { get; set; } = null!;
        public Exercise Exercise { get; set; } = null!;
    }

}
