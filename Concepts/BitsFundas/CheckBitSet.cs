using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsFundas
{
    /// <summary>
    //! Check if ith bit set for the number 
    /// </summary>
    public class CheckBitSet
    {
        public static bool CheckIfithBitSet(int n,int i)
        {
            int mask = (1 << i);
            return (n & mask) !=0 ? true : false;
        }

    }
}
