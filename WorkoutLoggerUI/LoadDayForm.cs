using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkoutLoggerUI;
using WorkoutLoggerLibrary;
using WorkoutLoggerLibrary.Models;
using System.Configuration;
using System.IO;

namespace WorkoutLoggerUI
{
    public partial class LoadDayForm : Form
    {
        /// <summary>
        /// The main window form that will get passed once this
        /// window opens
        /// </summary>
        public WorkoutViewerForm WorkoutForm { get; set; }

        /// <summary>
        /// A bool to indicate if the current window has closed
        /// </summary>
        public bool FormOpen { get; set; } = true;

        public LoadDayForm(WorkoutViewerForm workoutForm)
        {
            InitializeComponent();
            ListAddition();
            WorkoutForm = workoutForm;
        }

        #region Form Components

        private void buttonLoadDay_Click(object sender, EventArgs e)
        {
            //TODO - Change this in future for BIN
            string loadDate = $"{ listViewDays.SelectedItems[0].Text }{ Utility.FileExtension() }";
            string filePath = Utility.FindFile(loadDate, false);
            GlobalConfig.DayData = GlobalConfig.Connection.Loading<DateModel>(filePath);

            this.Close();
            FormOpen = false;
        }

        private void buttonDeleteDay_Click(object sender, EventArgs e)
        {
            //TODO - Change this in future for BIN
            string deleteTemplate = $"{ listViewDays.SelectedItems[0].Text }{ Utility.FileExtension() }";
            string path = ConfigurationManager.AppSettings["filePath"];
            //TODO - Change this in future for BIN
            IEnumerable<string> files = Directory.GetFiles(path, $"*{ Utility.FileExtension() }", SearchOption.TopDirectoryOnly);

            foreach (string file in files)
            {
                if (file.Contains(deleteTemplate)) File.Delete(file); break;
            }

            foreach(ListViewItem eachItem in listViewDays.SelectedItems)
            {
                listViewDays.Items.Remove(eachItem);
            }


        }

        private void buttonExitForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        /// <summary>
        /// Adding the parsed file data to the ListView
        /// </summary>
        private void ListAddition()
        {

            // Find the folder for the day data, get all the files in that folder,
            // iterate through the files and use the method to parse the data,
            // then add the data to the listview

            string dayFilePath = $"{ ConfigurationManager.AppSettings["filePath"] }";
            IEnumerable<string> files = Directory.GetFiles(dayFilePath, $"*{ Utility.FileExtension() }"
                , SearchOption.TopDirectoryOnly).Select(x => Path.GetFileName(x)).Reverse();

            foreach (string file in files)
            {
                string[] parsedFile = ParsedFile(file);
                listViewDays.Items.Add(new ListViewItem( new[] { parsedFile[1], parsedFile[0] } ));
            }

        }

        /// <summary>
        /// Parses the file name into a useable format for the listView
        /// </summary>
        /// <param name="file">The file name that will be parsed</param>
        /// <returns>Returns a String[2] with the needed data in it</returns>
        private string[] ParsedFile(string file)
        {
            // Create the new array, catch the date substring from the 
            // file name, then replace the _ with / to make it look nicer
            // find the index of the "." and then use it to find the 
            // name of the day. Return the parsed array.

            string[] parsed = new string[2];

            parsed[0] = file.Substring(0, 10).Replace("_", "/");
            
            int position = file.IndexOf(".") - 10;
            parsed[1] = file.Substring(10, position);

            return parsed;

        }


    }
}
