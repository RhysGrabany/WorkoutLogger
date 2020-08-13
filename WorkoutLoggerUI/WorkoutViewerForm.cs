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

                model
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
    }
}
