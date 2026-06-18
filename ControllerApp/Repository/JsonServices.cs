using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ControllerApp.Repository
{
    public static class JsonServices
    {
        public static void SerializeToJson<T>(T data, string filePath)
        {
            string jsonString = JsonSerializer.Serialize(data);
            System.IO.File.WriteAllText(filePath, jsonString);
        }

        public static T DeserializeFromJson<T>(string jsonString)
        {
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
