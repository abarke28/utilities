using System;
using System.Xml;
using System.Xml.Serialization;

namespace utilities
{
    public static class Serializer
    {
        public static void SerializeToXmlFile<T>(string filePath, object file)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using XmlWriter xmlWriter = XmlWriter.Create(filePath);
            xmlSerializer.Serialize(xmlWriter, file);
        }

        public static T DeserializeFromXmlFile<T>(string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using XmlReader xmlReader = XmlReader.Create(filePath);
            return (T)xmlSerializer.Deserialize(xmlReader);
        }
    }
}
