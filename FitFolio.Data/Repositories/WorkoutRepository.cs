using FitFolio.Data.Access;
using FitFolio.Data.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFolio.Data.Repositories
{
    public class WorkoutRepository : RepositoryBase<Workout>
    {       
        public WorkoutRepository(string connectionString)
            : base(connectionString)
        {            
        }

        public override void Create(Workout item)
        {
            _context.Workouts.Add(item);
            _context.SaveChanges();
        }

        public override void Delete(Workout item)
        {
            _context.Workouts.Remove(item);
            _context.SaveChanges();
        }

        public override IEnumerable<Workout> Find(Func<Workout, bool> predicate)
        {
            return _context.Workouts.Where(predicate);
        }

        public override Workout Get<TId>(TId id)
        {
            var _id = (Guid)Convert.ChangeType(id, typeof(Guid));
            return _context.Workouts.FirstOrDefault(x => x.Id == _id);
        }

        public override IEnumerable<Workout> GetAll()
        {
            return _context.Workouts.ToList();
        }

        public override void Update(Workout item)
        {
            _context.Workouts.Update(item);
            _context.SaveChanges();
        }
    }
}
