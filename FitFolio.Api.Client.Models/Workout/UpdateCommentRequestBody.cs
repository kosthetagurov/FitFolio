namespace FitFolio.Api.Client.Models.Workout
{
    public class UpdateCommentRequestBody
    {
        public Guid WorkoutId { get; set; }
        public string Comment { get; set; }
    }
}
