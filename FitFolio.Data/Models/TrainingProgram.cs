using System.ComponentModel.DataAnnotations.Schema;

namespace FitFolio.Data.Models
{
    public class TrainingProgram
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public ICollection<TrainingProgramWorkout> Workouts { get; set; } = new List<TrainingProgramWorkout>();
    }

}
