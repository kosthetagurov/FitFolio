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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual List<WorkoutDetail> WorkoutDetails { get; set; }
    }
}
