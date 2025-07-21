using System.ComponentModel.DataAnnotations.Schema;

namespace FitFolio.Data.Models
{
    /// <summary>
    /// Категория упражнения
    /// </summary>
    public class ExerciseCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
