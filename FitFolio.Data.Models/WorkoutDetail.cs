using System.ComponentModel.DataAnnotations.Schema;

namespace FitFolio.Data.Models
{
    public class WorkoutDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid WorkoutId { get; set; }
        public Guid ExerciseId { get; set; }
        public int? Sets { get; set; }
        public int? Repetitions { get; set; }
        public float? Weight { get; set; }
        public int? Duration { get; set; }

        public Workout Workout { get; set; } = null!;
        public Exercise Exercise { get; set; } = null!;
    }
}
