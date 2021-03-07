using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDesign.Hard
{
    class _588
    {
    }
    public class FileSystem
    {
        private Directory Root;
        public FileSystem()
        {
            Root = new Directory();
        }
        public IList<string> Ls(string path)
        {
            List<string> result = new List<string>();
            if (path == "/")
            {
                result.AddRange(Root.Files.Keys);
                result.AddRange(Root.Dirs.Keys);
                result.Sort();
                return result;
            }
            string[] tokens = path.Split('/');
            int n = tokens.Length;

            var curr = Root;
            //! starting from 1 becuase when we split, first token will be empty string
            for (int i = 1; i < n - 1; ++i)
            {
                string token = tokens[i];
                if (!curr.Dirs.ContainsKey(token))
                {
                    return result;
                }
                curr = curr.Dirs[token];
            }

            if (curr.Files.ContainsKey(tokens[n - 1]))
            {
                result.Add(tokens[n - 1]);
            }

            else
            {
                if (curr.Dirs.ContainsKey(tokens[n - 1]))
                {
                    curr = curr.Dirs[tokens[n - 1]];
                    result.AddRange(curr.Dirs.Keys);
                    result.AddRange(curr.Files.Keys);
                }
                result.Sort();
            }
            return result;
        }

        public void Mkdir(string path)
        {
            string[] tokens = path.Split('/');
            var curr = Root;
            for (int i = 1; i < tokens.Length; ++i)
            {
                string token = tokens[i];
                if (!curr.Dirs.ContainsKey(token))
                {
                    curr.Dirs.Add(token, new Directory());
                }
                curr = curr.Dirs[token];
            }
        }
        public void AddContentToFile(string filePath, string content)
        {
            string[] tokens = filePath.Split('/');
            var curr = Root;
            int n = tokens.Length;
            for (int i = 1; i < n - 1; ++i)
            {
                string token = tokens[i];
                if (!curr.Dirs.ContainsKey(token))
                {
                    curr.Dirs.Add(token, new Directory());
                }
                curr = curr.Dirs[token];
            }

            if (curr.Files.ContainsKey(tokens[n - 1]))
            {
                curr.Files[tokens[n - 1]].FileContent += content;
            }
            else
            {
                curr.Files.Add(tokens[n - 1], new File(content));
            }
        }
        public string ReadContentFromFile(string filePath)
        {

            string[] tokens = filePath.Split('/');
            var curr = Root;
            int n = tokens.Length;
            for (int i = 1; i < n - 1; ++i)
            {
                string token = tokens[i];
                if (!curr.Dirs.ContainsKey(token))
                {
                    return null;
                }
                curr = curr.Dirs[token];
            }

            if (curr.Files.ContainsKey(tokens[n - 1]))
            {
                return curr.Files[tokens[n - 1]].FileContent;
            }

            return null;
        }
    }

    public class Directory
    {
        public Dictionary<string, File> Files { get; set; }
        public Dictionary<string, Directory> Dirs { get; set; }
        public Directory()
        {
            Dirs = new Dictionary<string, Directory>();
            Files = new Dictionary<string, File>();
        }
    }

    public class File
    {
        public string FileContent;
        public File()
        {
            FileContent = null;

        }
        public File(string content)
        {
            FileContent = content;
        }
    }

}
