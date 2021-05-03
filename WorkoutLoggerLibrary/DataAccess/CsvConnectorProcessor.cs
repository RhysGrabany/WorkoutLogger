using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WorkoutLoggerLibrary.Models;

namespace WorkoutLoggerLibrary.DataAccess
{
    public static class CsvConnectorProcessor
    {


        public static List<CacheInfoModel> CsvLoad(this string path)
        {
            throw new NotImplementedException();
        }

        public static void CsvWrite<CacheInfoModel>(string CsvFormat, string fileName)
        {
            
            using (var fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine(CsvFormat);
                }
            }
        }

    }
}
