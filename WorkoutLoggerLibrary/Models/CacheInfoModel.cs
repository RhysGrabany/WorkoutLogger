using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutLoggerLibrary.Models
{
    public class CacheInfoModel
    {

        public CacheInfoModel() { }

        public CacheInfoModel(string name, DateTime date, bool template)
        {
            //TODO: Change this to check last id and then +1
            //Id = ReturnIdLastRecord();

            Name = name;
            Date = date;
            TemplateObject = template;
        }
        public CacheInfoModel(int id, string name,
            DateTime date, bool template)
        {
            Id = id;

            Name = name;
            Date = date;
            TemplateObject = template;

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool TemplateObject { get; set; } = false;

        public string CsvFormat()
        {
            return $"{ Id },{ Name },{Date:d},{ TemplateObject }";
        }

        public int ReturnIdLastRecord()
        {





            return 0;
        }

    }
}
