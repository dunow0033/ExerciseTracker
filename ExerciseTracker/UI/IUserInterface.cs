using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.UI
{
    internal interface IUserInterface
    {
        DateTime GetEndTime(DateTime startTime);
        int GetExerciseId(int id);
        DateTime GetStartTime();
    }
}
