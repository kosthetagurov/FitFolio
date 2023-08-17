using FitFolio.Data.Access;
using FitFolio.Data.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFolio.Data.Repositories
{
    public class ExerciseCategoryRepository : RepositoryBase<ExerciseCategory>
    {
        public ExerciseCategoryRepository(string connectionString)
            : base(connectionString)
        {
        }

        public override void Create(ExerciseCategory item)
        {
            _context.ExerciseCategories.Add(item);
            _context.SaveChanges();
        }

        public override void Delete(ExerciseCategory item)
        {
            _context.ExerciseCategories.Remove(item);
            _context.SaveChanges();
        }

        public override IEnumerable<ExerciseCategory> Find(Func<ExerciseCategory, bool> predicate)
        {
            return _context.ExerciseCategories.Where(predicate);
        }

        public override ExerciseCategory Get<TId>(TId id)
        {
            var _id = (Guid)Convert.ChangeType(id, typeof(Guid));
            return _context.ExerciseCategories.FirstOrDefault(x => x.Id == _id);
        }

        public override IEnumerable<ExerciseCategory> GetAll()
        {
            return _context.ExerciseCategories.ToList();
        }

        public override void Update(ExerciseCategory item)
        {
            _context.ExerciseCategories.Update(item);
            _context.SaveChanges();
        }
    }
}
