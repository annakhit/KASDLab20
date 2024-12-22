using System;
using System.IO;
using System.Reflection;

namespace KASDLab20
{
    internal class Program
    {
        readonly static string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        readonly static string pathToFile = directory + @"\output.txt";

        static void Main()
        {
            string[] rows = File.ReadAllLines("../../Data/input.txt");

            StreamWriter streamWriter = new StreamWriter(pathToFile);

            MyHashMap<string, MyVariable> hashMap = MyVariableParser.Parse(rows);

            Console.WriteLine();

            foreach (var entry in hashMap.EntrySet())
            {
                Console.WriteLine("{0} => {1}({2})", entry.Value.Type, entry.Value.Name, entry.Value.Value);
                streamWriter.WriteLine("{0} => {1}({2})", entry.Value.Type, entry.Value.Name, entry.Value.Value);
            }

            streamWriter.Close();

            Console.ReadKey();
        }
    }
}