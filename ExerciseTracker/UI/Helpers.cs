﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.UI
{
    internal static class Helpers
    {
        internal static Style HighLightStyle => new(
            Color.Orange1,
            Color.Black,
            Decoration.None
         );
        internal static void RenderTitle(string title)
        {
            Rule rule = new Rule($"[darkorange3]{title}[/]");
            AnsiConsole.Write(rule);
        }
        public static SelectionPrompt<MenuView> DisplayMainMenu()
        {
            AnsiConsole.Clear();
            RenderTitle("Main Menu");

            SelectionPrompt<MenuView> menu = new()
            {
                HighlightStyle = HighLightStyle
            };

            menu.Title("Select an [B]option[/]");
            menu.AddChoices(new List<MenuView>()
            {
                new() { Id = 0, Text = "Display Exercises" },
                new() { Id = 1, Text = "Add Exercise" },
                new() { Id = 2, Text = "Delete Exercise" },
                new() { Id = -1, Text = "Quit" }
            });

            return menu;
        }
    }
}
