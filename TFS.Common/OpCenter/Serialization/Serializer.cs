using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace TFS.OpCenter.Serialization
{
    public class Serializer
    {

        /// <summary>
        /// Converts an object of a generic type to an XML strign.
        /// </summary>
        public static string ConvertToXml<ObjectType>(object objectToConvert)
        {
            try
            {
                XmlSerializer xmlserializer = new XmlSerializer(typeof(ObjectType));
                StringWriter writer = new StringWriter();
                xmlserializer.Serialize(writer, objectToConvert);
                string xmlstring = writer.ToString();
                writer.Close();
                return xmlstring;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Converts a serialized string back to a generic object.
        /// </summary>
        public static ObjectType ConvertFromXml<ObjectType>(string xmlstring)
        {
            try
            {
                XmlSerializer xmlserializer = new XmlSerializer(typeof(ObjectType));
                StringReader reader = new StringReader(xmlstring);
                ObjectType deserializedObject = (ObjectType)xmlserializer.Deserialize(reader);
                reader.Close();
                return deserializedObject;
            }
            catch (Exception)
            {
                return default(ObjectType);
            }
        }

    }
}
