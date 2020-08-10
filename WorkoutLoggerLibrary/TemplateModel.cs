using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutLoggerLibrary
{
    public class TemplateModel
    {
        /// <summary>
        /// List of Exercises saved for the day
        /// </summary>
        public List<ExerciseModel> ExerciseDay { get; set; }
        /// <summary>
        /// The name given for this template of day
        /// </summary>
        public string NameDay { get; set; }
    }
}
