﻿using System.Globalization;

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
                        Console.ReadKey();
                        break;
                    case 1:
                        AddNewExercise();
                        break;
                    case 2:
                        DeleteExercise();
                        AnsiConsole.WriteLine("Press any key to return to main menu");
                        Console.ReadKey();
                        break;
                    case 3:
                        UpdateExercise();
                        break;
                    case -1:
                        AnsiConsole.WriteLine();
                        return;
                    default:
                        break;

                }
            }
        }
        private void DeleteExercise()
        {
            _exerciseService.DisplayExercises();
            int id = _exerciseUI.GetExerciseId(AnsiConsole.Ask<int>("Which exercise do you want to delete?"));
            if(id == -1)
            {
                return;
            }
            _exerciseService.DeleteExercise(id);
        }

        private void AddNewExercise() 
        {
            DisplayNewExerciseView(out DateTime startDate, out DateTime endDate, out string? comments);
            bool isSaved = _exerciseService.AddExercise(startDate, endDate, comments);
            if(isSaved)
            {
                AnsiConsole.WriteLine("Exercise has been saved");
            }
            else
            {
                AnsiConsole.WriteLine("Exercise has not been saved");
            }
            AnsiConsole.WriteLine("Press any key to return to main menu");
            Console.ReadKey();
        }

        private void UpdateExercise()
        {
            _exerciseService.DisplayExercises();
            int id = _exerciseUI.GetExerciseId(AnsiConsole.Ask<int>("Which exercise do you want to edit?"));
            if(id == -1) { return; }
            Exercise editExercise = _exerciseService.EditExercise(id);

            bool isUpdated = _exerciseService.UpdateExercise(DisplayEditExerciseView(editExercise));

            if(isUpdated)
            {
                AnsiConsole.WriteLine("Exercise has been updated!");
            }
            else
            {
                AnsiConsole.WriteLine("Couldn't update Exercise");
            }
            AnsiConsole.WriteLine("Press any key to return to main menu");
            Console.ReadKey();
        }

        private Exercise DisplayEditExerciseView(Exercise editExercise)
        {
            AnsiConsole.Clear();
            Helpers.RenderTitle($"Editing {editExercise.Id} Exercise");

            string dateStart, dateEnd;

            do
            {
                dateStart = AnsiConsole.Ask($"Edit the start of this exercise, Format : {dateFormat}", editExercise.DateStart.ToString(dateFormat, cultureInfo));
                if (!Validator.ValidateDateTime(dateStart))
                {
                    AnsiConsole.WriteLine($"Invalid date, make sure the format is {dateFormat}");
                }
            } while (!Validator.ValidateDateTime(dateStart));

            do
            {
                do
                {
                    dateEnd = AnsiConsole.Ask($"Edit the end of this exercise, Format : {dateFormat}", editExercise.DateEnd.ToString(dateFormat, cultureInfo));
                    if (!Validator.ValidateDateTime(dateEnd))
                    {
                        AnsiConsole.WriteLine($"Invalid date, make sure the format is {dateFormat}");
                    }
                } while (!Validator.ValidateDateTime(dateEnd));
            } while (!Validator.AreDatesValid(DateTime.ParseExact(dateStart, dateFormat, cultureInfo), DateTime.ParseExact(dateEnd, dateFormat, cultureInfo)));

            AnsiConsole.WriteLine($"Edit current comments : '{editExercise.Comments}', press enter to continue");
            string comments = Console.ReadLine();

            editExercise.DateStart = DateTime.Parse(dateStart);
            editExercise.DateEnd = DateTime.Parse(dateEnd);

            if(comments != editExercise.Comments && comments != "")
            {
                editExercise.Comments = comments;
            }

            return editExercise;
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
