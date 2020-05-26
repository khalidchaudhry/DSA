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
            /*
                 !For input: ["root/a 1.txt(abcd) 2.txt(efgh)", "root/c 3.txt(abcd)", "root/c/d 4.txt(efgh)", "root 4.txt(efgh)"]
                 
                 Key(FileContent)        Value(FilePath) 
                 abcd                   {root/a/1.txt,root/c/3.txt}
                 efgh                   {root/a/2.txt,root/c/d/4.txt,root/4.txt }
             
             */
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
