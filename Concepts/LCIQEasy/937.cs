using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCIQEasy
{
    class _937
    {
        public string[] ReorderLogFiles(string[] logs)
        {
            List<string> digitsLogs = new List<string>();
            List<string> lettersLogs = new List<string>();
            foreach (string log in logs)
            {
                var firstLogEntry = log.Substring(log.IndexOf(' ') +1)[0];

                if (Char.IsDigit(firstLogEntry))
                {
                    digitsLogs.Add(log);
                }
                else
                {
                    lettersLogs.Add(log);
                }
            }

            lettersLogs.Sort((a, b) =>
                {
                    string a_SubStr = a.Substring(a.IndexOf(' ') + 1);
                    string b_SubStr = b.Substring(b.IndexOf(' ') + 1);
                    int result=a_SubStr.CompareTo(b_SubStr);
                    if (result == 0)
                    {
                        result = a.Substring(0,a.IndexOf(' ')-1).CompareTo(b.Substring(0, b.IndexOf(' ')-1));

                    }
                    return result;

                });

            // Where i got stuck

            //var val = lettersLogs.OrderBy(x => x.Substring(x.IndexOf(' ') + 1)).ToList();
            //for (int i = 0; i < val.Count() - 1; i++)
            //{
            //    if (val[i].Substring(val[i].IndexOf(' ') + 1) == val[i + 1].Substring(val[i + 1].IndexOf(' ') + 1))
            //    {

            //    }
            //}

            lettersLogs.AddRange(digitsLogs);

            return lettersLogs.ToArray();

        }


    }
}
