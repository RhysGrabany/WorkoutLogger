using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace WorkoutLoggerLibrary.DataAccess
{
    public static class SerialiseUtility
    {

        public static string ModelToXml<T>(T model)
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(model.GetType());
            var xmlSettings = new XmlWriterSettings()
            {
                OmitXmlDeclaration = true,
                ConformanceLevel = ConformanceLevel.Auto,
                Indent = true
            };


            using (StringWriter sr = new StringWriter())
            {
                using (XmlWriter xml = XmlWriter.Create(sr, xmlSettings))
                {
                    writer.Serialize(xml, model);
                    return sr.ToString();
                }
            }

        }


    }
}
