using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDesign.Medium
{
    public class _355
    {
    }

    /// <summary>
    /// https://leetcode.com/problems/design-twitter/discuss/82825/Java-OO-Design-with-most-efficient-function-getNewsFeed
    /// </summary>
    public class Twitter
    {
        //Key will be user id and set will be list of users that user is following
        Dictionary<int, User> _users;
        private static int _timeStamp = 0;


        public Twitter()
        {
            _users = new Dictionary<int, User>();
        }

        /** Compose a new tweet. */
        public void PostTweet(int userId, int tweetId)
        {
            if (!_users.ContainsKey(userId))
            {
                _users.Add(userId, new User(userId));
            }

            _users[userId].Post(tweetId);

        }

        /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
        public IList<int> GetNewsFeed(int userId)
        {
            IList<int> ans = new List<int>();

            if (!_users.ContainsKey(userId)) return ans;

            HashSet<int> users = _users[userId].Follows;
            //! sorted in descending order to get 10 most recent tweet ids
            var comparer = Comparer<Tweet>.Create((x, y) => y.TimeStamp.CompareTo(x.TimeStamp));

            SortedSet<Tweet> pq = new SortedSet<Tweet>(comparer);

            foreach (int user in users)
            {
                Tweet t = _users[user].TweetHead;
                //! incase there is no tweet by user. No point of adding it to the pq
                if (t != null)
                {
                    pq.Add(t);
                }
            }

            while (pq.Count != 0 && ans.Count < 10)
            {
                Tweet maxTweetId = pq.First(); //! based on comparer First is actually having maximum tweet id now
                pq.Remove(pq.First());

                ans.Add(maxTweetId.TweetId);
                
                if (maxTweetId.Next != null)
                    pq.Add(maxTweetId.Next);
            }

            return ans;
        }

        /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
        public void Follow(int followerId, int followeeId)
        {
            if (!_users.ContainsKey(followerId))
            {
                User u = new User(followerId);
                _users.Add(followerId, u);
            }
            if (!_users.ContainsKey(followeeId))
            {
                User u = new User(followeeId);
                _users.Add(followeeId, u);
            }

            _users[followerId].Follows.Add(followeeId);
        }

        /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
        public void Unfollow(int followerId, int followeeId)
        {
            if (!_users.ContainsKey(followerId) ||  //! If followerId is not in the users list  
                followerId == followeeId) //! User can't unfollow him 
                return;

            _users[followerId].Follows.Remove(followeeId);

        }

        public class User
        {
            public int UserId { get; set; }
            //! reason for using hashset is because we need to remove the follower in constant time
            public HashSet<int> Follows { get; set; }  //! User follows who

            //! TweetHead because we can get top 10 tweets from user or other users that this user is following. 
            public Tweet TweetHead { get; set; }

            public User(int userId)
            {
                UserId = userId;
                Follows = new HashSet<int>();
                Follow(userId); //! first follow itself
                TweetHead = null;
            }
            public void Follow(int userId)
            {
                Follows.Add(userId);

            }
            public void UnFollow(int userId)
            {
                Follows.Remove(userId);
            }
            public void Post(int tweetId)
            {
                Tweet t = new Tweet(tweetId, ++_timeStamp);
                //! adding the node at the very beggining
                //! The latest tweet will be pointed by the TweetHead
                t.Next = TweetHead;
                TweetHead = t;
            }
        }

        //! Single linked list
        public class Tweet
        {
            public int TweetId { get; set; }

            public int TimeStamp { get; set; }

            public Tweet Next { get; set; }

            public Tweet(int tweetId, int timeStamp)
            {
                TweetId = tweetId;
                TimeStamp = timeStamp;
                Next = null;
            }

        }
    }
}
