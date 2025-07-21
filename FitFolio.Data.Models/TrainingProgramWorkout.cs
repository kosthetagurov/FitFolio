using System.ComponentModel.DataAnnotations.Schema;

namespace FitFolio.Data.Models
{
    [Obsolete(error: true, message: "Not used")]
    public class TrainingProgramWorkout
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid ProgramId { get; set; }
        public string Name { get; set; } = null!;
        public int Order { get; set; }

        public TrainingProgram Program { get; set; } = null!;
        public ICollection<TrainingProgramExercise> Exercises { get; set; } = new List<TrainingProgramExercise>();
    }

}
