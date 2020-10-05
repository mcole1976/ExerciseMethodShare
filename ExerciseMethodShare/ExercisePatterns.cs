using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;


namespace ExerciseMethodShare
{
    public class ExercisePatterns
    {
        public static List<string> exerciseStringList()
        {
            List<string> w = new List<string>();
            string[] workoutNames = Directory.GetFiles(Properties.Resources.XMLExerciseLocation);
            foreach (string a in workoutNames)
            {
                w.Add(a.Split('\\').Last());

            }

            return w;
        }

        public static Dictionary<string, string> fnSetDictionary()
        {
            Dictionary<string, string> workouts = new Dictionary<string, string>();

            string[] workoutNames = Directory.GetFiles(Properties.Resources.XMLMainXMLLocation);
            foreach (string a in workoutNames)
            {
                workouts.Add(a, a.Split('\\').Last());

            }


            return workouts;
        }

       

        public static string[] FnGetNames( List<ResultBase> rb)
        {

            string[] res =
            (from r in rb where r.Rank == 1 select r.Exercise_Name).Distinct().ToArray();

            return res;
        }

        public static string[]  FnGetTypes(List<ResultBase> rb)
        {
            string[] res =
                (from r in rb where r.Rank == 1 select r.Exercise_Name).Distinct().ToArray();

            return res;
        }

        public static ResultBase[] CreateResBaseList()
        {
            List<ResultBase> rb = new List<ResultBase>();
            string fileLoc = Properties.Resources.XMLBaseLoc;
            string JSON = File.ReadAllText(fileLoc);
            rb = JsonSerializer.Deserialize<List<ResultBase>>(JSON);
            rb = rb.Distinct().ToList();

            return rb.ToArray();
        }

        public static ResultBase[] CreateRuleSetList()
        {
            List<ResultBase> rb = new List<ResultBase>();
            string fileLoc = Properties.Resources.XMLRuleCheckLoc;

            FileSystemInfo fileInfo =
                new DirectoryInfo(fileLoc).GetFileSystemInfos().OrderBy(fi => fi.CreationTime).First();

            fileLoc = fileInfo.ToString();

            string JSON = File.ReadAllText(fileLoc);
            rb = JsonSerializer.Deserialize<List<ResultBase>>(JSON);
            rb = rb.Distinct().ToList();

            return rb.ToArray();
        }
    }
}
