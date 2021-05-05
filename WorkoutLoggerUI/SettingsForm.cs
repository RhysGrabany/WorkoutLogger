using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkoutLoggerLibrary;

namespace WorkoutLoggerUI
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            LoadPreviousSettings();
        }

        #region Form Components 

        #region Open Folder Buttons

        private void buttonTemplateFolder_Click(object sender, EventArgs e)
        {
            if (openFolderTemplates.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(openFolderTemplates.FileName);
                textBoxTemplatesLoc.Text = folderPath;
                Settings.Instance.TemplatesDataFile = folderPath;
                Settings.Update();
            }
        }

        private void buttonDaysFolder_Click(object sender, EventArgs e)
        {
            if (openFolderDays.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(openFolderDays.FileName);
                textBoxDaysLoc.Text = folderPath;
                Settings.Instance.DaysDataFile = folderPath;
                Settings.Update();
            }
        }

        #endregion

        #region Radio Buttons

        #region File Format Radio Buttons

        private void radioJson_CheckedChanged(object sender, EventArgs e)
        {
            if (radioJson.Checked)
            {
                Settings.Instance.DatabaseConnection = DatabaseType.JSON;
            }
            Settings.Update();
        }

        private void radioXML_CheckedChanged(object sender, EventArgs e)
        {
            if (radioXML.Checked)
            {
                Settings.Instance.DatabaseConnection = DatabaseType.XML;
            }
            Settings.Update();
        }
        
        #endregion

        #region Unit Type Radio Buttons
        private void radioMetric_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMetric.Checked)
            {
                Settings.Instance.UnitSystem = UnitType.METRIC;
            }
            Settings.Update();
        }

        private void radioImperial_CheckedChanged(object sender, EventArgs e)
        {
            if (radioImperial.Checked)
            {
                Settings.Instance.UnitSystem = UnitType.IMPERIAL;
            }
            Settings.Update();
        }

        #endregion

        #endregion

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void LoadPreviousSettings()
        {
            switch (Settings.Instance.DatabaseConnection)
            {
                case DatabaseType.JSON:
                    radioJson.Checked = true;
                    break;
                case DatabaseType.XML:
                    radioXML.Checked = true;
                    break;
                default:
                    break;
            }

            switch (Settings.Instance.UnitSystem)
            {
                case UnitType.METRIC:
                    radioMetric.Checked = true;
                    break;
                case UnitType.IMPERIAL:
                    radioImperial.Checked = true;
                    break;
                default:
                    break;
            }

            textBoxDaysLoc.Text = Settings.Instance.DaysDataFile;
            textBoxTemplatesLoc.Text = Settings.Instance.TemplatesDataFile;

        }


    }
}
