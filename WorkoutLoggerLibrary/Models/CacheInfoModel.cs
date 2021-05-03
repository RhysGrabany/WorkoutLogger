using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutLoggerLibrary.Models
{
    public class CacheInfoModel
    {

        public int Id { get; set; } = 1;
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool TemplateObject { get; set; } = false;

        public string CsvFormat()
        {
            return $"{ this.Id },{ this.Name },{ this.Date },{ this.TemplateObject }";
        }

    }
}
