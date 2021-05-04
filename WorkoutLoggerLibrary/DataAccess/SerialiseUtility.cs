using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WorkoutLoggerLibrary.DataAccess
{
    public static class SerialiseUtility
    {

        public static string ModelToXml<T>(T model)
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(model.GetType());
            using(StringWriter sr = new StringWriter())
            {
                writer.Serialize(sr, model);
                return sr.ToString();
            }

        }


    }
}
