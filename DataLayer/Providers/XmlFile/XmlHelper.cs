using System.Xml.Serialization;
using System.Xml;

namespace DataLayer.Providers.XmlFile
{
    public static class XmlHelper
    {
        public static void WriteToFile(object obj, string filePath)
        {
            var serializer = new XmlSerializer(obj.GetType());
            var settings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true };

            using (XmlWriter writer = XmlWriter.Create(filePath, settings))
            {
                serializer.Serialize(writer, obj);
            }
        }

        public static T ReadFromFile<T>(string filePath)
        {
            var streamReader = new StreamReader(filePath);

            try
            {
                var result = Parse<T>(streamReader.ReadToEnd());
                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                streamReader.Close();
            }
        }

        private static T Parse<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stringReader = new StringReader(xml))
            {
                return (T)serializer.Deserialize(stringReader)!;
            }
        }
    }
}
