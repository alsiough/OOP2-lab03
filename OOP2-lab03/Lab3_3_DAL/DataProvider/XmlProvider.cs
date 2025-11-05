using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Lab3_3_DAL.DataProvider
{
    public class XmlProvider : IDataProvider
    {
        public void Serialize<T>(T data, string path)
        {
            var xs = new XmlSerializer(typeof(T));
            using var fs = new StreamWriter(path, false, Encoding.Unicode);
            xs.Serialize(fs, data);
        }

        public T Deserialize<T>(string path)
        {
            var xs = new XmlSerializer(typeof(T));
            using var fs = new StreamReader(path, Encoding.Unicode);
            return (T)xs.Deserialize(fs)!;
        }
    }
}
