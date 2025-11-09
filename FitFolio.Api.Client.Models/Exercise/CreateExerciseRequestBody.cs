namespace FitFolio.Api.Client.Models.Exercise
{
    public class CreateExerciseRequestBody
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}

