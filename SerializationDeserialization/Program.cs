using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace SerializationDeserialization
{
    internal class Program
    {

        public static string PathString;


        static void Main(string[] args)
        {
            PathString = Path.GetFullPath(Path.Combine("..", "..", "..", "Files", "names.json"));
            List<string> names = new List<string>();
            Add("Pepe",names);
            Add("Keloglan", names);
            Delete(0, names);
            Add("Niloya", names);
            Console.WriteLine(Search("Niloya", names)); 
            GetJson(PathString,names);

        }
        static void GetJson(string path, List<string> names)
        {
            string newresult;
            using (StreamReader sr = new StreamReader(path))
            {
                newresult = sr.ReadToEnd();
            }
            names = JsonConvert.DeserializeObject<List<string>>(newresult);
        }
        static void SetJson(string path, List<string> names)
        {
            string result = JsonConvert.SerializeObject(names);
            using StreamWriter sw = new(path);

            sw.WriteLine(result);
        }
        static void Add(string name,List<string>names)
        {
            names.Add(name);
            SetJson(PathString,names);

        }
        static bool Search(string name,List<string>names)
        {
            Predicate<string> predicate = x => x.Contains(name);
            return predicate(name);
        }
        static void Delete(int index,List<string>names)
        {
            string name = names.Find(n => n == names[index]);
            names.RemoveAt(index);
            SetJson(PathString,names);
        }

    }
}
