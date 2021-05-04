using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutLoggerLibrary.Models
{
    public class DateModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Name of the day in a short sense
        /// </summary>
        public string NameDay { get; set; }
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
        public decimal WeightDay { get; set; }

        /// <summary>
        /// Any further descriptions that can be added to 
        /// this day
        /// </summary>
        public string DescriptionDay { get; set; }

        public DateModel() { }

        public DateModel(
            int id,
            string nameDay,
            List<ExerciseModel> exercisesDay, 
            string weightDay,
            string descriptionDay)
        {
            Id = id;
            NameDay = nameDay;

            ExercisesDay = exercisesDay;

            decimal weightDayValue = 0;
            decimal.TryParse(weightDay, out weightDayValue);
            WeightDay = Math.Round(weightDayValue, 2);

            DescriptionDay = descriptionDay;

            DateDay = DateTime.Today;
        }
    }
}
