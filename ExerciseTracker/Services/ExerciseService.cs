using ExerciseTracker.Models;
using ExerciseTracker.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.Services
{
    internal class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public bool AddExercise(DateTime start, DateTime end, string? comments)
        {
            Exercise newExercise = new()
            {
                DateStart = start,
                DateEnd = end,
                Duration = end - start,
                Comments = comments
            };
            return _exerciseRepository.AddExercise(newExercise);
        }

        public void DeleteExercise(int id)
        {
            if(!_exerciseRepository.GetExerciseById(id, out Exercise? exerciseToDelete))
            {
                AnsiConsole.WriteLine("Couldn't find the exercise you wanted to delete");
                return;
            }
            if(exerciseToDelete == null)
            {
                AnsiConsole.WriteLine("Something went wrong when trying to get the exercise");
                return;
            }
            _exerciseRepository.DeleteExercise(exerciseToDelete);
            AnsiConsole.WriteLine("Successfully deleted exercise.");
        }

        public void DisplayExercises()
        {
            List<Exercise> exercises = _exerciseRepository.GetExercises().ToList();
            UserInterface.DisplayExerciseTable(exercises);
        }

        public Exercise EditExercise(int id)
        {
            return _exerciseRepository.EditExerciseById(id);
        }

        public bool UpdateExercise(Exercise exercise)
        {
            return _exerciseRepository.EditExercise(exercise);
        }
    }
}
