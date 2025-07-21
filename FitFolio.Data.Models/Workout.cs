using System.ComponentModel.DataAnnotations.Schema;

namespace FitFolio.Data.Models
{
    /// <summary>
    /// Тренировка
    /// </summary>
    public class Workout
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; } = null!;
        public Guid? ProgramWorkoutId { get; set; }
        public string? Notes { get; set; }

        public ICollection<WorkoutDetail> Details { get; set; } = new List<WorkoutDetail>();
    }
}
