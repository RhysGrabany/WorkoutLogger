using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkoutLoggerLibrary;

namespace WorkoutLoggerUI
{
    public partial class WorkoutViewerForm : Form
    {
        public WorkoutViewerForm()
        {
            InitializeComponent();
        }

        private void buttonSaveDay_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                DateModel model = new DateModel();
                List<ExerciseModel> exercises = ExerciseReturn();

                
            }

        }

        /// <summary>
        /// Checks the filled in textboxes if they are valid or not
        /// </summary>
        /// <returns>Boolean True/False: True for valid, False for invalid</returns>
        private bool ValidateForm()
        {
            bool output = true;

            float weightNo = 0;
            bool weightNoValid = float.TryParse(textBoxWeightDay.Text, out weightNo);
            if (!weightNoValid)
            {
                output = false;
            }

            if (weightNo < 1)
            {
                output = false;
            }

            // TODO - Check for skipped boxes for exercise textboxes
            // This loops through the Exercise Text Boxes to check if they have any
            // text inside them. If they do then the maxNoExercises is increased
            // This does not take into account for any skipped boxes
            int maxNoExercises = 0;
            for (int i = 1; i < 11; i++)
            {
                TextBox exerciseBox = (TextBox)this.Controls["textBoxEx" + i.ToString()];
                if (exerciseBox.Text.Length > 0)
                {
                    maxNoExercises += 1;
                }
            }

            float weightSet = 0;
            int repSet = 0;
            
            // This checks if there is any exercises actually logged into
            // the program before starting the WaR checks
            if (maxNoExercises < 1)
            {
                output = false;
            }

            // TODO - Does not check for negative numbers
            // This loops through the number of exercises that the form has, then
            // it loops through the WaR text boxes
            // First it checks if any of the text boxes have a length, if yes then 
            // it will check if it is a valid value, otherwise it is skipped
            // This does take into account for skipped textboxes
            for (int exercise = 1; exercise < maxNoExercises+1; exercise++)
            {
                for (int war = 1; war < 6; war++)
                {
                    TextBox weightBox = (TextBox)this.Controls["textBoxEx" + exercise.ToString() + "We" + war.ToString()];
                    TextBox repBox = (TextBox)this.Controls["textBoxEx" + exercise.ToString() + "Re" + war.ToString()];

                    float weightBoxValue = 0;
                    if (weightBox.Text.Length > 0)
                    {
                        bool weightBoxValid = float.TryParse(weightBox.Text, out weightBoxValue);
                        if (!weightBoxValid)
                        {
                            output = false;
                        }
                    }

                    int repBoxValue = 0;
                    if (repBox.Text.Length > 0)
                    {
                        bool repBoxValid = int.TryParse(repBox.Text, out repBoxValue);
                        if (!repBoxValid)
                        {
                            output = false;
                        }
                    }

                }
            }


            return output;
        }

        // TODO - Deal with the magic numbers in these three methods (in the FOR loops)
        /// <summary>
        /// This is the method that creates a List<ExerciseModel> that will have the 
        /// details populated with the correct reps, weights, sets, and name
        /// </summary>
        /// <returns>Returns a List<ExerciseModel> that can be used</returns>
        private List<ExerciseModel> ExerciseReturn()
        {
            
            List<ExerciseModel> exercises = new List<ExerciseModel>();

            for (int i = 1; i < 11; i++)
            {
                string exercise;
                TextBox exerciseBox = (TextBox)this.Controls["textBoxEx" + i.ToString()];
                if (exerciseBox.Text.Length > 0)
                {
                    exercise = exerciseBox.Text;
                    List<int> reps = RepsList(i);
                    int sets = reps.Capacity;
                    List<float> weights = WeightsList(i, sets);

                    exercises.Add(new ExerciseModel(exercise, sets, reps, weights));

                } 
                else
                {
                    break;
                }
            }

            return exercises;
        }

        /// <summary>
        /// This populates a List<int> of the reps in the exercise
        /// </summary>
        /// <param name="exerciseNo">The exercise number</param>
        /// <returns>List<int> of reps completed for the exercise</returns>
        private List<int> RepsList(int exerciseNo)
        {
            List<int> reps = new List<int>();

            for (int i = 1; i < 6; i++)
            {
                TextBox repBox = (TextBox)this.Controls["textBoxEx" + exerciseNo.ToString() + "Re" + i.ToString()];
                
                int repsValue = 0;
                if (repBox.Text.Length > 0)
                {
                    int.TryParse(repBox.Text, out repsValue);
                    reps.Add(repsValue);
                }
            }

            return reps;

        }

        /// <summary>
        /// This populates a List<float> of the weights used for the exercise
        /// </summary>
        /// <param name="exerciseNo">This is the current number for the exercise</param>
        /// <param name="noOfSets">This is how many sets there are for the weights (this means you can skip weights)</param>
        /// <returns>Returns a populated list of what weights were used for the exercise</returns>
        private List<float> WeightsList(int exerciseNo, int noOfSets)
        {
            List<float> weights = new List<float>();

            for (int i = 1; i < noOfSets+1; i++)
            {
                TextBox weightBox = (TextBox)this.Controls["textBoxEx" + exerciseNo.ToString() + "Re" + i.ToString()];

                // If the weight text box is empty, but there's still sets to look over,
                // The last used weight will be added to the List
                // e.g. {7.5, 19.5} -> next weight box is empty, add last used weight -> {7.5, 19.5, 19.5}
                // Then it will continue
                float weightValue = 0;
                if (weightBox.Text.Length == 0)
                {
                    weights.Add(weights.Last());
                } 
                else
                {
                    float.TryParse(weightBox.Text, out weightValue);
                    weights.Add(weightValue);
                }
            }

            return weights;
        }


    }
}
