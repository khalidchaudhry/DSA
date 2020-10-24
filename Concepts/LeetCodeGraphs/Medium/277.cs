using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _277
    {

    }

    public class Solution : Relation
    {
        //https://leetcode.com/problems/find-the-celebrity/solution/
        //https://www.youtube.com/watch?v=aENYremq77I
        public int FindCelebrity(int n)
        {
            int candidateCelebrity = 0;
            for (int i = 1; i < n; ++i)
            {
                if (Knows(candidateCelebrity, i))
                {
                    candidateCelebrity = i;
                }
            }

            if (IsCelebrity(candidateCelebrity,n))
            {
                return candidateCelebrity;
            }
            return -1;
        }

        private bool IsCelebrity(int candidateCelebrity,int total)
        {
            for (int i = 0; i < total; ++i)
            {
                if (i == candidateCelebrity) continue;
                //! !Knows(i, candidateCelebrity) because there can be two people who don't know each other 
                //! and none of them should be celebrity 
                //!e.g for input [[1,0],[0,1]]
                //!Knows(i,candidateCelebrity) ensures that person i knows celebrity 
                if (Knows(candidateCelebrity, i) || !Knows(i,candidateCelebrity))
                    return false;
            }

            return true;
        }
    }

    //! This class is not given Implemented here just to test
    public class Relation
    {
        public bool Knows(int a, int b)
        {
            return false;
        }
    }
}
