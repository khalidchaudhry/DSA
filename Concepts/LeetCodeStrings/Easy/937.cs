using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStrings.Easy
{
    class _937
    {
        public string[] ReorderLogFiles(string[] logs)
        {
            List<string> digitsLogs = new List<string>();
            List<string> lettersLogs = new List<string>();
            foreach (string log in logs)
            {
                var firstLogEntry = log.Substring(log.IndexOf(' ') + 1)[0];

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
                    //!letter logs
                    string a_SubStr = a.Substring(a.IndexOf(' ') + 1);
                    //!letter logs
                    string b_SubStr = b.Substring(b.IndexOf(' ') + 1);
                    int result = a_SubStr.CompareTo(b_SubStr);
                    //!If logs are equal then use identifier to sort. 
                    if (result == 0)
                    {
                        result = a.Substring(0, a.IndexOf(' ') - 1).CompareTo(b.Substring(0, b.IndexOf(' ') - 1));
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

        public string[] ReorderLogFiles2(string[] logs)
        {
            List<string> digitsLogs = new List<string>();
            List<LetterLogs> lettersLogs = new List<LetterLogs>();
            string[] result = new string[logs.Length];
            foreach (string log in logs)
            {
                int indexOfSpace = log.IndexOf(' ');
                string id = log.Substring(0, indexOfSpace);
                string logData = log.Substring(indexOfSpace + 1);
                if (char.IsDigit(logData[0]))
                {
                    digitsLogs.Add(log);
                }
                else
                {
                    lettersLogs.Add(new LetterLogs(id, logData));
                }
            }

            List<LetterLogs> orderedletterLogs = lettersLogs.OrderBy(x => x.LogData).ThenBy(x=>x.Identifier).ToList();

            int j = 0;
            for (int i = 0; i < logs.Length; i++)
            {
                if (i < orderedletterLogs.Count)
                {
                    result[i] = orderedletterLogs[i].ToString();
                }
                else
                {
                    result[i] =digitsLogs[j++];
                }
            }

            return result;
        }
    }

    public class LetterLogs
    {
        public string Identifier { get; }
        public string LogData { get; }
        public LetterLogs(string idenifier, string logData)
        {
            Identifier = idenifier;
            LogData = logData;
        }

        public override string ToString()
        {
            return $"{Identifier} {LogData}";
        }
    }

}
