using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDesign.Medium
{
    class _1348
    {
    }
    public class TweetCounts
    {

        Dictionary<string, List<int>> _tweetTimes;
        public TweetCounts()
        {
            _tweetTimes = new Dictionary<string, List<int>>();

        }

        public void RecordTweet(string tweetName, int time)
        {

            if (!_tweetTimes.ContainsKey(tweetName))
            {
                _tweetTimes.Add(tweetName, new List<int>());
            }
            _tweetTimes[tweetName].Add(time);

        }

        public IList<int> GetTweetCountsPerFrequency(string freq, string tweetName, int startTime, int endTime)
        {

            if (!_tweetTimes.ContainsKey(tweetName))
                return new List<int>();

            int delta = 0;
            if (freq == "minute")
            {
                delta = 60;
            }
            else if (freq == "hour")
            {
                delta = 60 * 60;
            }
            else
            {
                delta = 60 * 60 * 24;
            }

            int totalBuckets = (endTime - startTime) / delta + 1;

            int[] buckets = new int[totalBuckets];
            foreach (int time in _tweetTimes[tweetName])
            {
                if (time >= startTime && time <= endTime)
                {
                    ++buckets[(time - startTime) / delta];
                }
            }

            return buckets.ToList();

        }
    }
    
 /* Definition for a binary tree node.*/
  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
  }

}
