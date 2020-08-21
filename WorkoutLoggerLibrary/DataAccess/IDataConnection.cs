using System;
using System.Collections.Generic;
using System.Text;
using WorkoutLoggerLibrary.Models;

namespace WorkoutLoggerLibrary.DataAccess
{
    public interface IDataConnection
    {
        /// <summary>
        /// Saves the DateModel to a data connections
        /// </summary>
        /// <param name="model">The model being saved using data connections</param>
        /// <returns>The model being passed</returns>
        DateModel CreateDay(DateModel model);

        /// <summary>
        /// Saves a TemplateModel to a data connections
        /// </summary>
        /// <param name="model">The model being saved using the data connections</param>
        /// <returns>The model being passed</returns>
        TemplateModel CreateTemplate(TemplateModel model);

        DateModel LoadDate(string path);
        
        TemplateModel LoadTemplate(string path);


    }
}
