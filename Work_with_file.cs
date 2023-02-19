using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezhednevnik
{
    internal class Work_with_file
    {
        public static void My_Serialize<T>(T zametki, string file_name)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = JsonConvert.SerializeObject(zametki);
            File.WriteAllText(desktop + "//" + file_name, json);
        }

        public static T My_Deserialize<T>(string file_name)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(desktop + "//" + file_name);
            T zametki = JsonConvert.DeserializeObject<T>(json);
            return zametki;
        }
    }
}
