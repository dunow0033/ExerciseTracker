using System.Globalization;

namespace ExerciseTracker.Controllers
{
    internal class ExerciseController : IExerciseController
    {
        private readonly IExerciseService _exerciseService;
        private readonly IUserInterface _exerciseUI;
        private readonly string dateFormat = "MM-dd-yyyy HH:mm";
        private readonly CultureInfo cultureInfo = new CultureInfo("en-US");
        public ExerciseController(IExerciseService exerciseService, IUserInterface userInterface)
        {
            _exerciseService = exerciseService;
            _exerciseUI = userInterface;
        }

        public void Run()
        {
            if(_exerciseService == null)
            {
                throw new ArgumentNullException();
            }

            while(true)
            {
                int selectedOption = AnsiConsole.Prompt(Helpers.DisplayMainMenu()).Id;

                switch(selectedOption)
                {
                    case 0:
                        _exerciseService.DisplayExercises();
                        AnsiConsole.WriteLine("Press any key to return to main menu");
                        Console.ReadLine();
                        break;
                    case 1:
                        AddNewExercise();
                        break;
                }
            }
        }

        private void AddNewExercise() 
        {
            DisplayNewExerciseView(out DateTime startDate, out DateTime endDate, out string? comments);
        }

        private void DisplayNewExerciseView(out DateTime startDate, out DateTime endDate, out string? comments)
        {
            AnsiConsole.Clear();
            Helpers.RenderTitle("Add new exercise");

            string start, end;

            do
            {
                start = AnsiConsole.Ask<string>($"What date did you start this exercise? Format : {dateFormat}");
                if (!Validator.ValidateDateTime(start))
                {
                    AnsiConsole.WriteLine($"Invalid date, make sure the format is {dateFormat}");
                }
            } while(!Validator.ValidateDateTime(start));

            do
            {
                do
                {
                    end = AnsiConsole.Ask<string>($"What date did you finish this exercise? Format : {dateFormat}");
                    if (!Validator.ValidateDateTime(end))
                    {
                        AnsiConsole.WriteLine($"Invalid date, make sure the format is {dateFormat}");
                    }
                } while (!Validator.ValidateDateTime(end));
            } while (!Validator.AreDatesValid(DateTime.ParseExact(start, dateFormat, cultureInfo), DateTime.ParseExact(end, dateFormat, cultureInfo)));

            startDate = DateTime.ParseExact(start, dateFormat, cultureInfo);
            endDate = DateTime.ParseExact(end, dateFormat, cultureInfo);

            AnsiConsole.WriteLine("Any comments for this exercise?, press enter to contiue");
            comments = Console.ReadLine();
        }
    }
}
