using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutLoggerLibrary.Models
{
	public class ExerciseModel
	{
        /// <summary>
        /// The name for the selected exercise
        /// </summary>
		public string ExerciseName { get; set; }
        /// <summary>
        /// The number of sets for the selected exercise
        /// </summary>
        public int ExerciseSets { get; set; }
        /// <summary>
        /// The reps for the number of sets done for the exercise
        /// </summary>
        public List<int> ExerciseReps { get; set; } = new List<int>();
        /// <summary>
        /// The weight completed for the exercise for each rep
        /// </summary>
        public List<float> ExerciseWeight { get; set; } = new List<float>();

        public ExerciseModel()
        {

        }

        public ExerciseModel(
            string exerciseName, 
            int exerciseSets, 
            List<int> exerciseReps, 
            List<float> exerciseWeight)
        {
            ExerciseName = exerciseName;

            ExerciseSets = exerciseSets;

            ExerciseReps = exerciseReps;

            ExerciseWeight = exerciseWeight;


        }

    }
}
