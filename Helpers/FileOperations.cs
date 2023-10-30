using System.Text.Json.Serialization;
using System.Text.Json;

namespace HotelPremium.Helpers
{
    public static class FileOperations
    {
        private static readonly JsonSerializerOptions _options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };

        public static void SimpleWrite(object obj, string fileName)
        {
            string jsonString = JsonSerializer.Serialize(obj, _options);
            File.WriteAllText(fileName, jsonString);
        }

        public static void PrettyWrite(object obj, string fileName)
        {
            var options = new JsonSerializerOptions(_options)
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(obj, options); //mvcore/hotelpremium/users.json
            File.WriteAllText(fileName, jsonString);
        }

        public static List<T> ReadFiles<T>(string fileName)
        {
            List<T> list;

            string[] arrayOfEachLines = File.ReadAllLines(fileName);
            string jsonTextBigString = File.ReadAllText(fileName);

            if(jsonTextBigString.Length == 0 || arrayOfEachLines.Length == 0)
            {
                return list = new List<T>();
            }

            var options = new JsonSerializerOptions(_options)
            {
                WriteIndented = true,
            };

            list = JsonSerializer.Deserialize<List<T>>(jsonTextBigString);

            return list;
        }

        public static void AppendElement<T>(object obj, string fileName)
        {
            var options = new JsonSerializerOptions(_options)
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(obj, options);

            File.AppendAllText(fileName, jsonString);
        }

        public static T ReadOne<T>(string fileName, string id)
        {

            string[] arrayOfEachLines = File.ReadAllLines(fileName);
            //string jsonTextBigString = File.ReadAllText(fileName);

            var options = new JsonSerializerOptions(_options)
            {
                WriteIndented = true,
            };

            string line = arrayOfEachLines.FirstOrDefault(x => x.Contains(id));

            T element = JsonSerializer.Deserialize<T>(line);

            return element;
        }
    }
}
