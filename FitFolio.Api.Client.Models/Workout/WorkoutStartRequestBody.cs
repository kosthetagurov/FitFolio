namespace FitFolio.Api.Client.Models.Workout
{
    public class WorkoutStartRequestBody
    {
        public Guid UserId { get; set; }
        public string? WorkoutName { get; set; }
    }
}
