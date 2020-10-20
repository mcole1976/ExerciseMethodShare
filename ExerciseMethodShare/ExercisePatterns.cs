using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;


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

        public static string[] FnGetNames(List<ResultBase> rb)
        {

            string[] res =
            (from r in rb where r.Rank == 1 select r.Exercise_Name).Distinct().ToArray();

            return res;
        }

        public static string[] FnGetTypes(List<ResultBase> rb)
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

        public static WorkOut[] readExercise(string xmlLoc)
        {
            WorkOut[] exs;

            List<WorkOut> w = new List<WorkOut>();
            string loc = Properties.Resources.XMLMainXMLLocation;
            loc = loc + @"\" + xmlLoc + ".xml";
            XElement xDoc = XElement.Load(loc);
            IEnumerable<XElement> childList =
            from el in xDoc.Elements()
            select el;
            foreach (XElement e in childList)
            {
                WorkOut wOut = new WorkOut();
                wOut.Id = Convert.ToInt32(e.Element("order").Value.ToString());
                wOut.Name = e.Element("name").Value.ToString();
                wOut.Time = Convert.ToInt32(e.Element("time").Value.ToString());
                w.Add(wOut);
            }   


            return w.ToArray(); 


        }

        public static Dictionary<string, int> fnSetCounts(List<ResultCount> rc, List<string> e)
        {
            Dictionary<string, int> res = new Dictionary<string, int>();
            int count = 0;

            foreach (string ex in e)
            {
                count = 0;
                count = (from c in rc where c.Exercise_category == ex select c).Count();
                res.Add(ex, count);
            }

            return res;
        }

        public  ResultCount[] fnSetReults(List<string> exes, List<string> exerciseRegime, List<ResultBase> rb, int v)
        {

            List<ResultCount> res = new List<ResultCount>();

            foreach (string ex in exes)
            {
                foreach (string exType in exerciseRegime)
                {
                    int c =
                    (from r in rb where r.Rank == v && r.Exercise_Type == ex && r.Exercise_Name == exType select r.Exercise_Name).Distinct().Count();
                    //exercise over exercise type
                    if (c > 0)
                    {
                        ResultCount rCnt = new ResultCount();
                        rCnt.Excount = c;
                        rCnt.Exercise_category = ex;
                        rCnt.Exercise_name = exType;
                        res.Add(rCnt);
                    }

                }
            }


            return res.ToArray();
        }

    }
}
