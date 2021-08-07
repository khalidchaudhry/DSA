using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsFundas
{
    public static class SetBit
    {
        public static int SetithBit(int n,int pos)
        {
            int mask = 1 << pos;
            return n | mask;
            
        }


    }
}
