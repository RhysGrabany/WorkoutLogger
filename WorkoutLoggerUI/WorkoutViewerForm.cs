﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WorkoutLoggerLibrary;
using WorkoutLoggerLibrary.DataAccess;
using WorkoutLoggerLibrary.Models;

namespace WorkoutLoggerUI
{
    public partial class WorkoutViewerForm : Form
    {
        // Consts for the number of exercises and sets for the form
        // no real need having more unless push comes to shove
        public const int NoOfExercises = 10;
        public const int NoOfSets = 5;

        public WorkoutViewerForm()
        {
            InitializeComponent();
            PopulateComboBox();
        }

        #region Form Components

        #region Day Components

        private void buttonSaveDay_Click(object sender, EventArgs e)
        {
            // Checks if the form is valid
            // If yes, then it will create a new entry for DBConnection and move the model over, then clear boxes
            // If no, then message box will show warning the user and will not save nor clear the boxes
            if (ValidateForm())
            {
                string dailyWeight = textBoxWeightDay.Text;
                string nameDay = textBoxDayName.Text;
                string descriptionDay = textBoxDescription.Text;
                List<ExerciseModel> exercises = ExerciseReturn(false);

                DateModel model = new DateModel(nameDay, exercises, dailyWeight, descriptionDay);

                Directory.CreateDirectory($"{ ConfigurationManager.AppSettings["filePath"] }");
                GlobalConfig.Connection.CreateDay(model);

                ClearTextboxes();

            }
            else
            {
                MessageBox.Show("This form has invalid information.\nPlease check and try again.");
            }

        }

        private void buttonLoadDay_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Template Components
        /// <summary>
        /// Method that dictates what happens when the Save Template button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveTemplate_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                string nameTemplate = textBoxTemplate.Text;

                List<ExerciseModel> exercises = ExerciseReturn(true);
                TemplateModel model = new TemplateModel(nameTemplate, exercises);

                Directory.CreateDirectory($"{ ConfigurationManager.AppSettings["tfilePath"] }");
                GlobalConfig.Connection.CreateTemplate(model);

                comboBoxLoad.Items.Add(nameTemplate.Replace(" ", ""));

            }
            else
            {
                MessageBox.Show("This form has invalid information.\nPlease check and try again");
            }

        }

        private void buttonTemplateDelete_Click(object sender, EventArgs e)
        {
            // load in the text for the template to be deleted (add the .xml to make it more exact)
            // loaad in the path, then get all files and and then delete the first one that 
            // matches the text for the template
            // then remove that option from the combobox
            string deleteTemplate = comboBoxLoad.Text + ".xml";
            string path = ConfigurationManager.AppSettings["tfilePath"];
            IEnumerable<string> files = Directory.GetFiles(path, "*.xml", SearchOption.TopDirectoryOnly);

            foreach (string file in files)
            {
                if (file.Contains(deleteTemplate)) File.Delete(file); break;
            }

            comboBoxLoad.Items.Remove(deleteTemplate);
        }
        private void buttonLoadTemplate_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #endregion

        #region Form Validation

        /// <summary>
        /// Checks the filled in textboxes if they are valid or not
        /// </summary>
        /// <param name="template">Bool whether validate Template class or not</param>
        /// <returns>Boolean True/False: True for valid, False for invalid</returns>
        private bool ValidateForm()
        {
            bool output = true;

            float weightNo = 0;
            bool weightNoValid = float.TryParse(textBoxWeightDay.Text, out weightNo);
            if (!weightNoValid && textBoxWeightDay.Text != "" && weightNo < 0)
            {
                output = false;
            }

            // This loops through the Exercise Text Boxes to check if they have any
            // text inside them. If they do then the maxNoExercises is increased
            // This does not take into account for any skipped boxes
            int maxNoExercises = 0;
            for (int i = 1; i < 11; i++)
            {
                TextBox exerciseBox = (TextBox)this.Controls["textBoxEx" + i.ToString()];
                // This is a placeholder box, basically checks if the exercise box was skipped
                // might be used when an exercise is a continuation
                TextBox phWeightBox = (TextBox)this.Controls["textBoxEx" + i.ToString() + "We1"];
                if (exerciseBox.Text.Length > 0 || phWeightBox.Text.Length > 0)
                {
                    maxNoExercises += 1;
                }
            }

            // This checks if there is any exercises actually logged into
            // the program before starting the WaR checks
            if (maxNoExercises < 1)
            {
                output = false;
            }

            // This loops through the number of exercises that the form has, then
            // it loops through the Weight And Rep(WaR) text boxes
            // First it checks if any of the text boxes have a length, if yes then 
            // it will check if it is a valid value, otherwise it is skipped
            // This does take into account for skipped textboxes
            for (int exercise = 1; exercise < maxNoExercises + 1; exercise++)
            {
                for (int war = 1; war < 6; war++)
                {
                    TextBox weightBox = (TextBox)this.Controls["textBoxEx" + exercise.ToString() + "We" + war.ToString()];
                    TextBox repBox = (TextBox)this.Controls["textBoxEx" + exercise.ToString() + "Re" + war.ToString()];

                    float weightBoxValue = 0;
                    bool weightBoxValid = true;
                    if (weightBox != null && weightBox.Text != "")
                    {
                        weightBoxValid = float.TryParse(weightBox.Text, out weightBoxValue);
                        if (!weightBoxValid && weightBoxValue < 0)
                        {
                            output = false;
                        }
                    }

                    bool repBoxValid = true;
                    int repBoxValue = 0;
                    if (repBox != null && repBox.Text != "")
                    {
                        repBoxValid = int.TryParse(repBox.Text, out repBoxValue);
                        if (!repBoxValid || repBoxValue < 0)
                        {
                            output = false;
                        }
                    }

                    if (!weightBoxValid || !repBoxValid)
                    {
                        break;
                    }

                }
            }
            return output;
        }

        #endregion

        #region Parsing of TextBox Exercise Data

        /// <summary>
        /// This is the method that creates a List<ExerciseModel> that will have the 
        /// details populated with the correct reps, weights, sets, and name
        /// </summary>
        /// <returns>Returns a List<ExerciseModel> that can be used</returns>
        private List<ExerciseModel> ExerciseReturn(bool template)
        {

            List<ExerciseModel> exercises = new List<ExerciseModel>();

            for (int i = 1; i < NoOfExercises+1; i++)
            {
                string exercise;
                TextBox exerciseBox = (TextBox)this.Controls["textBoxEx" + i.ToString()];
                // This is a placeholder box, basically checks if the exercise box was skipped
                // might be used when an exercise is a continuation
                TextBox phWeightBox = (TextBox)this.Controls["textBoxEx" + i.ToString() + "We1"];
                if (exerciseBox.Text.Length > 0 || phWeightBox.Text.Length > 0)
                {
                    exercise = exerciseBox.Text;
                    List<int> reps = RepsList(i);
                    List<float> weights = WeightsList(i);
                    int sets = template ? weights.Count : reps.Count;

                    if (!template)
                    {
                        exercises.Add(new ExerciseModel(exercise, sets, reps, weights));
                    } 
                    else
                    {
                        exercises.Add(new ExerciseModel(exercise, sets, weights));
                    }

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
        private List<int> RepsList(int exercise)
        {
            List<int> reps = new List<int>();

            for (int i = 1; i < NoOfSets+1; i++)
            {
                TextBox repBox = (TextBox)this.Controls["textBoxEx" + exercise.ToString() + "Re" + i.ToString()];

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
        /// <returns>Returns a populated list of what weights were used for the exercise</returns>
        private List<float> WeightsList(int exercise)
        {
            List<float> weights = new List<float>();

            for (int i = 1; i < NoOfSets+1; i++)
            {
                TextBox weightBox = (TextBox)this.Controls["textBoxEx" + exercise.ToString() + "We" + i.ToString()];

                // If the weight text box is empty, but there's still sets to look over,
                // The last used weight will be added to the List
                // e.g. {7.5, 19.5} -> next weight box is empty, add last used weight -> {7.5, 19.5, 19.5}
                // Then it will continue
                float weightValue = 0;
                if (weightBox is null)
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

        #endregion

        #region General Utilities

        // Utilities - Clear Exercise Textboxes

        /// <summary>
        /// This method clears all the Exercise, Weight, Rep, and Daily Weight
        /// text boxes.
        /// </summary>
        private void ClearTextboxes()
        {

            textBoxWeightDay.Text = "";
            textBoxDayName.Text = "";

            for (int exercise = 1; exercise < NoOfExercises+1; exercise++)
            {
                for (int set = 1; set < NoOfSets+1; set++)
                {
                    TextBox exerciseBox = (TextBox)this.Controls["textBoxEx" + exercise.ToString()];
                    TextBox repBox = (TextBox)this.Controls["textBoxEx" + exercise.ToString() + "Re" + set.ToString()];
                    TextBox weightBox = (TextBox)this.Controls["textBoxEx" + exercise.ToString() + "We" + set.ToString()];

                    exerciseBox.Text = "";
                    repBox.Text = "";
                    weightBox.Text = "";

                }
            }
        }

        /// <summary>
        /// This method will populate the combobox dropdown
        /// by going through the templates saved and adding them
        /// to the pile.
        /// </summary>
        private void PopulateComboBox()
        {
            // save the file location for templates
            // Get the files in the template folder, only load the *.xml files,
            // then get the file names for each file (exclude the paths)
            string templateFolder = ConfigurationManager.AppSettings["tfilePath"];
            IEnumerable<string> files = Directory.GetFiles(templateFolder, "*.xml", SearchOption.TopDirectoryOnly).Select(x => Path.GetFileName(x));

            // run through the files, and remove everything except the name
            // finally add each item to the combobox
            foreach (string file in files)
            {
                int position = file.IndexOf(".") - 10;
                comboBoxLoad.Items.Add(file.Substring(10, position));
            }


        }

        #endregion

    }
}
