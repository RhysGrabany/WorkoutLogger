using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutLoggerLibrary
{
    public class DateModel
    {
        /// <summary>
        /// The date the selected day is on
        /// </summary>
        public DateTime DateDay { get; set; }
        /// <summary>
        /// The list of exercises completed on this day
        /// </summary>
        public List<ExerciseModel> ExercisesDay { get; set; }
        /// <summary>
        /// The weight the user was during this day
        /// </summary>
        public float WeightDay { get; set; }
        /// <summary>
        /// Any further descriptions that can be added to 
        /// this day
        /// </summary>
        public string DescriptionDay { get; set; }
    }
}
