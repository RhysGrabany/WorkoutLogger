using System;
using System.Collections.Generic;
using System.Text;
using WorkoutLoggerLibrary.Models;

namespace WorkoutLoggerLibrary.DataAccess
{
    public interface IDataConnection
    {
        DateModel CreateDay(DateModel model);
    }
}
