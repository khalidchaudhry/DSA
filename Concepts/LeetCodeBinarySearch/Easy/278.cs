using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Easy
{
    public class _278
    {
        public class Solution : VersionControl
        {

            //!FF'T'TTTT
            public int FirstBadVersion(int n)
            {
                int lo = 0;
                int hi = n;
                while (lo + 1 < hi)
                {
                    int mid = lo + ((hi - lo) / 2);

                    if (IsBadVersion(mid))
                    {
                        hi = mid;
                    }
                    else
                    {
                        lo = mid;
                    }
                }

                return hi;
            }
        }
    }

    public class VersionControl
    {
        public bool IsBadVersion(int version)
        {
            return true;
        }
    }
}
