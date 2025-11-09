namespace FitFolio.Api.Client.Models.ExerciseCategory
{
    public class UpdateExerciseCategoryRequestBody
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}

