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

namespace WorkoutLoggerUI
{
    public partial class LoadDayForm : Form
    {

        public WorkoutViewerForm WorkoutForm { get; set; }

        public bool FormOpen { get; set; } = true;

        public LoadDayForm(WorkoutViewerForm workoutForm)
        {
            InitializeComponent();
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

    }
}
