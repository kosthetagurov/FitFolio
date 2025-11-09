namespace FitFolio.Api.Client.Models.Exercise
{
    public class UpdateExerciseRequestBody
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}

