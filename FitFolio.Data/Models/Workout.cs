using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public TrainingProgramWorkout? ProgramWorkout { get; set; }
        public ICollection<WorkoutDetail> Details { get; set; } = new List<WorkoutDetail>();
    }
}
