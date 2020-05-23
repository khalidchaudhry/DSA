using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _609
    {
        public IList<IList<string>> FindDuplicate(string[] paths)
        {

            List<IList<string>> result = new List<IList<string>>();
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            if (paths.Length == 0)
                return result;

            foreach (string path in paths)
            {
                string[] directoryInfo = path.Split(' ');
                //starting from 1 because 0 index contains directory path
                for (int i = 1; i < directoryInfo.Length; i++)
                {
                    int indexOf = directoryInfo[i].IndexOf('(');
                    string fileName = directoryInfo[i].Substring(0, indexOf);
                    string fileContent = directoryInfo[i].Substring(indexOf + 1, directoryInfo[i].Length - indexOf - 2);

                    StringBuilder sb = new StringBuilder();
                    // Appending directoryPath
                    sb.Append(directoryInfo[0]);
                    sb.Append("/");
                    sb.Append(fileName);

                    if (map.ContainsKey(fileContent))
                    {
                        map[fileContent].Add(sb.ToString());
                    }
                    else
                    {
                        List<string> filePath = new List<string>();
                        filePath.Add(sb.ToString());
                        map.Add(fileContent, filePath);
                    }
                }
            }

            foreach (KeyValuePair<string, List<string>> keyValue in map)
            {
                //!Question asks only to retuns group of duplicate file paths. 
                if (keyValue.Value.Count > 1)
                {
                    result.Add(keyValue.Value);
                }
            }

            return result;
        }

    }
}
