using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciseTracker.Models;

namespace ExerciseTracker.Services
{
    internal interface IExerciseService
    {
        bool AddExercise(DateTime start, DateTime end, string? comments);
        void DeleteExercise(int id);
        Exercise EditExercise(int id);
        bool UpdateExercise(Exercise exercise);
        void DisplayExercises();
    }
}
