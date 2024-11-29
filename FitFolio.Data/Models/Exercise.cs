using System.ComponentModel.DataAnnotations.Schema;

namespace FitFolio.Data.Models
{
    /// <summary>
    /// Упражнение
    /// </summary>
    public class Exercise
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }

        public ExerciseCategory Category { get; set; } = null!;
    }

}
