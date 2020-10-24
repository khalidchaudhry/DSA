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


        public IList<string> Crawl(string startUrl, HtmlParser htmlParser)
        {

            // Extract domain name from startUrl
            string domainName = $"http://{new Uri(startUrl).Host}";
            List<string> result = new List<string>();
            HashSet<string> seen = new HashSet<string>();
            DFS(startUrl, domainName, seen, result, htmlParser);
            return result;
        }
        private void DFS(string url, string domainName, HashSet<string> seen, List<string> result, HtmlParser htmlParser)
        {
            seen.Add(url);
            result.Add(url);

            IList<string> neighbours = htmlParser.GetUrls(url);

            foreach (string neighbour in neighbours)
            {
                if (!seen.Contains(neighbour) &&
                    neighbour.StartsWith(domainName)
                  )
                {
                    DFS(neighbour, domainName, seen, result, htmlParser);
                }
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
