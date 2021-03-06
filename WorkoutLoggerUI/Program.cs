﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkoutLoggerLibrary;

namespace WorkoutLoggerUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialise database connections
            Settings.Boot();
            GlobalConfig.InitialiseConnections(Settings.Instance.DatabaseConnection);

            Application.Run(new WorkoutViewerForm());
        }
    }
}
