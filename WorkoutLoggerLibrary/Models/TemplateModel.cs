using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutLoggerLibrary.Models
{
    public class TemplateModel
    {
        /// <summary>
        /// The name given for this template of day
        /// </summary>
        public string NameTemplate{ get; set; }

        /// <summary>
        /// List of Exercises saved for the day
        /// </summary>
        public List<ExerciseModel> ExerciseTemplate { get; set; } = new List<ExerciseModel>();

        public TemplateModel() { }

        public TemplateModel(string nameTemplate,
            List<ExerciseModel> exerciseTemplate)
        {
            NameTemplate = nameTemplate;
            ExerciseTemplate = exerciseTemplate;
        }
    }
}
