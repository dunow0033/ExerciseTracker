﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.UI
{
    public class MenuView
    {
        public int Id {  get; set; }
        public string? Text {  get; set; }
        public override string ToString() => Text;
    }
}
