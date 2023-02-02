using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UserLogin
{
    public class Logger
    {

        static private List<string> currentSessionActivities = new List<string>();
        

        static public void LogActivity(string activity)
        {
            DateTime dateTime = DateTime.Now;
            string activityLine = dateTime + ";" + /*LoginValidation.PotrebitelskoIme +*/ ";" + LoginValidation.CurrentUserRole + ";" + activity;
            currentSessionActivities.Add(activityLine);
            Console.WriteLine(activityLine);
            File.AppendAllText("test.txt", activityLine);
            Console.WriteLine("\n");
        }
        public static string PrintLogActivity()
        {
            StreamReader str = new StreamReader("test.txt");
            string logData = str.ReadToEnd();
            return logData;
        }

        public static IEnumerable<string> PrintCurrentSessionActivities()
        {
            StringBuilder stb = new StringBuilder();
            foreach (string str in currentSessionActivities)
            {
                stb.Append(str);
            }

            yield return stb.ToString();
        }
        public static IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            List<string> filteredActivities = (from activity in currentSessionActivities
                                              where activity.Contains(filter)
                                              select activity).ToList();
            return filteredActivities;
        }
        public static void DeleteOldDate(string file)
        {
            StreamReader sr = new StreamReader(file);
            StringBuilder stb = new StringBuilder();

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string lineDate = line.Substring(0, 9);
                DateTime date = DateTime.Parse(lineDate).Date;
                DateTime todayDate = DateTime.Now.Date;
                if (date.CompareTo(todayDate) < 0)
                {
                    continue;
                }
                stb.Append(line + "\n");

            }
            sr.Close();
            File.WriteAllText(file, stb.ToString());
        }

    }
}
