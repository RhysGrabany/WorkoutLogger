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
            TemplateModel test = new TemplateModel();
            test.NameTemplate = "Testing";
            WorkoutForm.TemplateData = test;
            this.Close();
            FormOpen = false;
        }

        private void buttonDeleteDay_Click(object sender, EventArgs e)
        {

        }

        private void buttonExitForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        private void ListAddition()
        {
            string dayFilePath = $"{ ConfigurationManager.AppSettings["filePath"] }";
            IEnumerable<string> files = Directory.GetFiles(dayFilePath, "*.xml", SearchOption.TopDirectoryOnly).Select(x => Path.GetFileName(x));

            foreach (string file in files)
            {
                
                listViewDays.Items.Add(new ListViewItem( new[] { "column1", "column2" } ));
            }
                      


        }

    }
}
