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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            LoadPreviousSettings();
            InitializeComponent();
        }
        private void buttonTemplateFolder_Click(object sender, EventArgs e)
        {

        }

        private void buttonDaysFolder_Click(object sender, EventArgs e)
        {

        }


        private void radioJson_CheckedChanged(object sender, EventArgs e)
        {
            GlobalConfig.DatabaseUsed = DatabaseType.JSON;
        }

        private void radioXML_CheckedChanged(object sender, EventArgs e)
        {
            GlobalConfig.DatabaseUsed = DatabaseType.XML;
        }

        private void radioMetric_CheckedChanged(object sender, EventArgs e)
        {
            GlobalConfig.UnitUsed = UnitType.METRIC;
        }

        private void radioImperial_CheckedChanged(object sender, EventArgs e)
        {
            GlobalConfig.UnitUsed = UnitType.IMPERIAL;
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadPreviousSettings()
        {
            switch (GlobalConfig.DatabaseUsed)
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

            switch (GlobalConfig.UnitUsed)
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

        }


    }
}
