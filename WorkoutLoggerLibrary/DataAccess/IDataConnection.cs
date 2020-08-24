using System;
using System.Collections.Generic;
using System.Text;
using WorkoutLoggerLibrary.Models;

namespace WorkoutLoggerLibrary.DataAccess
{
    public interface IDataConnection
    {
        /// <summary>
        /// Saves the DateModel to a data connections serialised
        /// </summary>
        /// <param name="model">The model being saved using data connections</param>
        /// <returns>The model being passed</returns>
        DateModel Creating(DateModel model);

        /// <summary>
        /// Saves a TemplateModel to a data connections
        /// </summary>
        /// <param name="model">The model being saved using the data connections</param>
        /// <returns>The model being passed</returns>
        TemplateModel Creating(TemplateModel model);

        /// <summary>
        /// Loads a serialised TemplateModel from file
        /// </summary>
        /// <param name="path">The path to which the Template is to be loaded from</param>
        /// <returns>The deserialised TemplateModel</returns>
        T Loading<T>(string path);


    }
}
