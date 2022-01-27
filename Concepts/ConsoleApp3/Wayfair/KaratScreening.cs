using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Wayfair
{
    public class KaratScreening
    {
        public static void KaratScreeningMain()
        {
            /*

              We are working on a security system for a badged-access room in our company's building.

              We want to find employees who badged into our secured room unusually often. We have an unordered list of names and entry times over a single day. Access times are given as numbers up to four digits in length using 24-hour time, such as "800" or "2250".

              Write a function that finds anyone who badged into the room three or more times in a one-hour period. Your function should return each of the employees who fit that criteria, plus the times that they badged in during the one-hour period. If there are multiple one-hour periods where this was true for an employee, just return the earliest one for that employee.

              1355 => 13:55 1pm 55mn
              10 => 00:10
              three or more times in a one-hour period

              badge_times = [
              ["Paul",      "1355"], ["Jennifer",  "1910"], ["Jose",    "835"],
              ["Jose",       "830"], ["Paul",      "1315"], ["Chloe",     "0"],
              ["Chloe",     "1910"], ["Jose",      "1615"], ["Jose",   "1640"],
              ["Paul",      "1405"], ["Jose",       "855"], ["Jose",    "930"],
              ["Jose",       "915"], ["Jose",       "730"], ["Jose",    "940"],
              ["Jennifer",  "1335"], ["Jennifer",   "730"], ["Jose",   "1630"],
              ["Jennifer",     "5"], ["Chloe",     "1909"], ["Zhang",     "1"],
              ["Zhang",       "10"], ["Zhang",      "109"], ["Zhang",   "110"],
              ["Amos",         "1"], ["Amos",         "2"], ["Amos",    "400"],
              ["Amos",       "500"], ["Amos",       "503"], ["Amos",    "504"],
              ["Amos",       "601"], ["Amos",       "602"], ["Paul",   "1416"]
              ];

              "Paul" :  1315 1355   1405   1416
              "Jose":   830  915 1615 855 730 835  930    940 1630
                        730  830 835 855  915 930  940    1615 1630


              Expected output (in any order)
              Paul: 1315 1355 1405
              Jose: 830 835 855 915 930
              Zhang: 10 109 110
              Amos: 500 503 504

              n: length of the badge records array

              map
              Key
              String     List<Time>
              Paul       1315

              1355-1315<=60

              /*
                count=0
                    ignore

                count=1
                    Convert to minute
                count=2
                    Convert to minute
                count=3
                    Convert first character substring to hour
                    Convert 2 to 3 to minute
                count==4 
                    Convert first and second substring to hour
                    Convert subtring from 2 to 3 to minute
                    Jose:      830 835 855 1615 1640


                    */



        }
        public static void Run()
        {
                string[][] badgeTimes = new string[][]{
                      new string[]{"Paul", "1355" },
                      new string[]{"Jennifer", "1910" },
                      new string[]{"Jose", "835" },
                      new string[]{"Jose", "830" },
                      new string[]{"Paul", "1315" },
                      new string[]{"Chloe", "0" },
                      new string[]{"Chloe", "1910" },
                      new string[]{"Jose", "1615" },
                      new string[]{"Jose", "1640" },
                      new string[]{"Paul", "1405" },
                      new string[]{"Jose", "855" },
                      new string[]{"Jose", "930" },
                      new string[]{"Jose", "915" },
                      new string[]{"Jose", "730" },
                      new string[]{"Jose", "940" },
                      new string[]{"Jennifer", "1335" },
                      new string[]{"Jennifer", "730" },
                      new string[]{"Jose", "1630" },
                      new string[]{"Jennifer", "5" },
                      new string[]{"Chloe", "1909" },
                      new string[]{"Zhang", "1" },
                      new string[]{"Zhang", "10"},
                      new string[]{"Zhang", "109" },
                      new string[]{"Zhang", "110" },
                      new string[]{"Amos", "1" },
                      new string[]{"Amos", "2" },
                      new string[]{"Amos", "400" },
                      new string[]{"Amos", "500"},
                      new string[] {"Amos", "503"},
                      new string[]{"Amos", "504" },
                      new string[] {"Amos", "601" },
                      new string[] {"Amos", "602" },
                      new string[]{"Paul", "1416" }
        };

            var test = CorrectSolution(badgeTimes);
            foreach (string str in test)
            {
                Console.WriteLine(str);
            }
            Console.ReadLine();


        }
        private static List<string> ProvidedSolution(string[][] badgeTimes)
        {
            Dictionary<string, List<int>> nameTime = new Dictionary<string, List<int>>();
            badgeTimes = badgeTimes.OrderBy(x => x[1]).ToArray();
            foreach (string[] badgeTime in badgeTimes)
            {
                string name = badgeTime[0];
                int time = Convert.ToInt32(badgeTime[1]);
                if (!nameTime.ContainsKey(name))
                {
                    nameTime.Add(name, new List<int>());
                }

                if (nameTime[name].Count == 0)
                {
                    nameTime[name].Add(time);
                }
                else
                {
                    int idx = nameTime[name].Count - 1;
                    int prevTime = nameTime[name][idx];
                    if (time - prevTime <= 60)
                    {
                        nameTime[name].Add(time);
                    }
                }
            }
            List<string> result = new List<string>();
            foreach (var keyValue in nameTime)
            {
                StringBuilder sb = new StringBuilder();
                if (keyValue.Value.Count >= 3)
                {
                    sb.Append(keyValue.Key);
                    sb.Append(':');

                    foreach (var time in keyValue.Value)
                    {
                        sb.Append(time);
                    }
                    result.Add(sb.ToString());
                }
            }
            return result;
        }

        private static List<string> CorrectSolution(string[][] badgeTimes)
        {
            Dictionary<string, List<string>> nameTime = new Dictionary<string, List<string>>();
            badgeTimes = badgeTimes.OrderBy(x => Convert.ToInt32(x[1])).ToArray();
            foreach (string[] badgeTime in badgeTimes)
            {
                string name = badgeTime[0];
                string currTimeStr = badgeTime[1];
                //Assuming entry are valid
                //if (currTime.Length <= 0)
                //{
                //    continue;

                if (!nameTime.ContainsKey(name))
                {
                    nameTime.Add(name, new List<string>());
                    nameTime[name].Add(currTimeStr);
                }
                else
                {                    
                    string firstTimeStr = nameTime[name][0];
                    if (Normalize(currTimeStr) - Normalize(firstTimeStr) <= 60)
                    {
                        nameTime[name].Add(currTimeStr);
                    }
                    else
                    {
                        if (nameTime[name].Count < 3)
                        {
                            while (nameTime[name].Count>0 && Normalize(currTimeStr) - Normalize(nameTime[name][0]) > 60)
                            {
                                nameTime[name].RemoveAt(0);                                
                            }
                            nameTime[name].Add(currTimeStr);
                        }
                    }
                }
            }

            List<string> result = new List<string>();
            foreach (var keyValue in nameTime)
            {
                StringBuilder sb = new StringBuilder();
                if (keyValue.Value.Count >= 3)
                {
                    sb.Append(keyValue.Key);
                    sb.Append(':');

                    foreach (var time in keyValue.Value)
                    {
                        sb.Append(time);
                        sb.Append(" ");
                    }
                    --sb.Length;
                    result.Add(sb.ToString());
                }
            }
            return result;

        }

        private static int Normalize(string timeStr)
        {
            int hour = 0;
            int minute = 0;
            if (timeStr.Length == 1)
            {
                minute = Convert.ToInt32(timeStr);
            }

            if (timeStr.Length == 2)
            {
                minute = Convert.ToInt32(timeStr);
            }
            else if (timeStr.Length == 3)
            {
                hour = Convert.ToInt32(timeStr.Substring(0, 1));
                minute = Convert.ToInt32(timeStr.Substring(1, 2));
            }
            else if (timeStr.Length == 4)
            {
                hour = Convert.ToInt32(timeStr.Substring(0, 2));
                minute = Convert.ToInt32(timeStr.Substring(2, 2));
            }
            int currTime = hour * 60 + minute;

            return currTime;
        }
    }
}
