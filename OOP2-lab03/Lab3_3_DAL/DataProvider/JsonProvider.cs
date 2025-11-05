using System.IO;
using System.Text;
using System.Text.Json;

namespace Lab3_3_DAL.DataProvider
{
    public class JsonProvider : IDataProvider
    {
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public void Serialize<T>(T data, string path)
        {
            var json = JsonSerializer.Serialize(data, _options);
            File.WriteAllText(path, json, Encoding.Unicode); // UTF-16 (Unicode) encoding
        }

        public T Deserialize<T>(string path)
        {
            var json = File.ReadAllText(path, Encoding.Unicode);
            return JsonSerializer.Deserialize<T>(json)!;
        }
    }
}
