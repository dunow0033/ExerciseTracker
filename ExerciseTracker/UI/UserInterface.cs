using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.UI
{
    internal class UserInterface : IUserInterface
    {
        private readonly IExerciseRepository _exerciseRepository;

        public UserInterface(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }
        public DateTime GetEndTime(DateTime startTime)
        {
            throw new NotImplementedException();
        }

        public int GetExerciseId(int id)
        {
            bool result = _exerciseRepository.GetExerciseById(id, out _);

            if(result)
            {
                return id;
            }
            return -1;
        }

        public DateTime GetStartTime()
        {
            throw new NotImplementedException();
        }

        public static void DisplayExerciseTable(List<Exercise> exercises) 
        {
            Table table = new Table();
            table.Expand();
            table.AddColumns("Id", "Date Started", "Date Ended", "Duration", "Comments");

            foreach(Exercise exercise in exercises)
            {
                table.AddRow($"{exercise.Id}", $"{exercise.DateStart}", $"{exercise.DateEnd}", $"{exercise.Duration}", $"{exercise.Comments}");
            }

            AnsiConsole.Write(table);
        }
    }
}
