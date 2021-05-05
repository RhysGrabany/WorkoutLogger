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
        void Creating(DateModel model);

        /// <summary>
        /// Saves a TemplateModel to a data connections
        /// </summary>
        /// <param name="model">The model being saved using the data connections</param>
        /// <returns>The model being passed</returns>
        void Creating(TemplateModel model);

        /// <summary>
        /// Loads a serialised TemplateModel from file
        /// </summary>
        /// <typeparam name="T">The model being loaded from file and deserialized</typeparam>
        /// <param name="path">The path to which the Template is to be loaded from</param>
        /// <returns>The deserialised TemplateModel</returns>
        T Loading<T>(string path, int id);


    }
}
