using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _1236
    {

        public static void _1236Main()
        {
            _1236 Main = new _1236();
            Main.Crawl("http://news.yahoo.com/news",new HtmlParser());
            Console.ReadLine();
        }


        /// <summary>
        //! Follow-up is more important for this question. Please take a look here 
        //https://leetcode.com/problems/web-crawler-multithreaded/discuss/890950/C-Using-ConcurrentDictionary-vs-Dictionary-%2B-lock
        /// </summary>
        public IList<string> Crawl(string startUrl, HtmlParser htmlParser)
        {

            if (startUrl == string.Empty)
                return new List<string>();
            string allowedDomain = new Uri(startUrl).Authority;
            HashSet<string> visited = new HashSet<string>();
            DFS(startUrl, allowedDomain, htmlParser, visited);
            return visited.ToList();
        }
        private void DFS(string url, string allowedDomain, HtmlParser htmlParser, HashSet<string> visited)
        {
            string domain = new Uri(url).Authority;
            if (domain != allowedDomain || visited.Contains(url))
            {
                return;
            }
            visited.Add(url);
            IList<string> neighbors = htmlParser.GetUrls(url);
            foreach (string neighbor in neighbors)
            {
                DFS(neighbor, allowedDomain, htmlParser, visited);
            }
        }
    }
    /// <summary>
    //! Its implementation is abstracted from us. Its in leetcode. I added here just for testing purpose 
    /// </summary>
    public class HtmlParser
    {
        public List<String> GetUrls(String url) {
            return new List<string>();
        }
    }
}
