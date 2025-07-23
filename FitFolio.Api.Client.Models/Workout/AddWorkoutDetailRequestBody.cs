namespace FitFolio.Api.Client.Models.Workout
{
    public class AddWorkoutDetailRequestBody
    {
        public Guid WorkoutId { get; set; }
        public Guid ExerciseId { get; set; }
        public int? Sets { get; set; }
        public int? Repetitions { get; set; }
        public float? Weight { get; set; }
        public int? Duration { get; set; }
    }
}
