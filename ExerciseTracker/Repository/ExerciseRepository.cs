using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciseTracker.Models;
using ExerciseTracker.Repository;
using ExerciseTracker.Context;

namespace ExerciseTracker.Repository
{
    internal class ExerciseRepository : IExerciseRepository
    {
        private readonly ExerciseContext _exerciseContext;
        public ExerciseRepository(ExerciseContext context) 
        {
            _exerciseContext = context;
        }
        public bool AddExercise(Exercise exercise)
        {
            _exerciseContext.Add(exercise);
            int result = _exerciseContext.SaveChanges();

            if(result > 0)
            {
                return true;
            }
            else { return false; }
        }

        public void DeleteExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }

        public bool EditExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }

        public Exercise EditExerciseById(int id)
        {
            throw new NotImplementedException();
        }

        public bool GetExerciseById(int id, out Exercise? exercise)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Exercise> GetExercises()
        {
            return _exerciseContext.Exercises;
        }
    }
}
