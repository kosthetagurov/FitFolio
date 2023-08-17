using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFolio.Data.Models
{
    public class WorkoutDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid WorkoutId { get; set; }
        public Guid ExerciseId { get; set; }
        public TimeSpan Duration { get; set; }
        /// <summary>
        /// Количество подходов
        /// </summary>
        public int? Sets { get; set; }
        /// <summary>
        /// Количество повторений
        /// </summary>
        public int? Reps { get; set; }
        public double? Weight { get; set; }
        public string? Notes { get; set; }

        public Workout Workout { get; set; }
        public Exercise Exercise { get; set; }
    }
}
