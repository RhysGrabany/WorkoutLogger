using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutLoggerLibrary.Models
{
    public class DateModel
    {
        /// <summary>
        /// Unique Id for the day
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The date the selected day is on
        /// </summary>
        public DateTime DateDay { get; set; }
        /// <summary>
        /// The list of exercises completed on this day
        /// </summary>
        public List<ExerciseModel> ExercisesDay { get; set; } = new List<ExerciseModel>();
        /// <summary>
        /// The weight the user was during this day
        /// </summary>
        public float WeightDay { get; set; }
        /// <summary>
        /// Any further descriptions that can be added to 
        /// this day
        /// </summary>
        public string DescriptionDay { get; set; }

        public DateModel()
        {
               
        }

        public DateModel(
            List<ExerciseModel> exercisesDay, 
            string weightDay)
        {
            ExercisesDay = exercisesDay;

            float weightDayValue = 0;
            float.TryParse(weightDay, out weightDayValue);
            WeightDay = weightDayValue;

        }
    }
}
