﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using WorkoutLoggerLibrary.Models;

namespace WorkoutLoggerLibrary.DataAccess
{
    public class CsvConnector
    {
        public List<CacheInfoModel> CsvLoad()
        {
            return CsvConnectorProcessor.CsvLoad(Utility.FullCacheFilePath());
        }

        public void Write(CacheInfoModel cacheModel)
        {
            string fileName = "cache.csv";
            cacheModel.CsvWrite(fileName);
        }
    }
}
