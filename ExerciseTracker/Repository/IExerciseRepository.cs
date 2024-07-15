using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciseTracker.Models;

namespace ExerciseTracker.Repository
{
    internal interface IExerciseRepository
    {
        public IEnumerable<Exercise> GetExercises();
        public bool GetExerciseById(int id, out Exercise? exercise);
        public Exercise EditExerciseById(int id);
        public bool AddExercise(Exercise exercise);
        public bool EditExercise(Exercise exercise);
        public void DeleteExercise(Exercise exercise);
    }
}
