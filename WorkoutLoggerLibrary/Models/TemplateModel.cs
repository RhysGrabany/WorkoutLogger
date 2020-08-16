using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutLoggerLibrary.Models
{
    public class TemplateModel
    {
        /// <summary>
        /// List of Exercises saved for the day
        /// </summary>
        public List<ExerciseModel> ExerciseTemplate { get; set; } = new List<ExerciseModel>();
        /// <summary>
        /// The name given for this template of day
        /// </summary>
        public string NameTemplate{ get; set; }
    }
}
