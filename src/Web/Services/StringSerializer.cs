using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Web.Services
{
    public static class StringSerializer
    {
        public static string Serialize<T>(T unknown)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new XmlSerializer(typeof(T));
                formatter.Serialize(stream, unknown);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public static T Deserialize<T>(string value)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(value)))
            {
                var formatter = new XmlSerializer(typeof(T));

                return (T)formatter.Deserialize(stream);
            }
        }

    }
}