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
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Name { get; set; } = null!;
        public string? Notes { get; set; }

        public ICollection<WorkoutDetail> Details { get; set; } = new List<WorkoutDetail>();
    }
}
