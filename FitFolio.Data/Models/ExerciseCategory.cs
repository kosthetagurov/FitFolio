using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFolio.Data.Models
{
    /// <summary>
    /// Категория упражнения
    /// </summary>
    public class ExerciseCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }

        public virtual List<Exercise> Exercises { get; set; }
    }
}
