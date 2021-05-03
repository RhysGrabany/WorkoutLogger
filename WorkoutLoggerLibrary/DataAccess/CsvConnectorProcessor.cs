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

            List<CacheInfoModel> retList = new List<CacheInfoModel>();

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (var sr = new StreamReader(fs))
                {
                    var headers = sr.ReadLine();

                    string line;
                    while((line = sr.ReadLine()) != null)
                    {
                        string[] lineSplit = line.Split(',');
                        //retList.Add(new CacheInfoModel(lineSplit[0], lineSplit[1], lineSplit[2], lineSplit[3]));
                    }
                }
            }

            throw new NotImplementedException();
        }

        public static void CsvWrite(this CacheInfoModel model, string fileName)
        {
            string fullFilePath = $"{ Utility.FullFolderPath() }\\{ fileName }";
            // TODO: Exception when file is open
            using (var fs = new FileStream(fullFilePath, FileMode.Append, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine(model.CsvFormat());
                }
            }
        }

    }
}
