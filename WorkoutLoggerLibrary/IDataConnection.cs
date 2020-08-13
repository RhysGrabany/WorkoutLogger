using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutLoggerLibrary
{
    public interface IDataConnection
    {
        DateModel CreateDay(DateModel model);
    }
}
