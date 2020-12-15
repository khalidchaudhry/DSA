using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bala
{
    public class _12102020
    {
        //! Tail Recursive function(work after recursive call)
        public  static void Count(int n)
        {
            if (n == 0)
                return;

            int parameter = n - 1;
            Count(parameter);
            Console.Write(n);
        }

        //! Head recursion(work before recursive call) 
        public  static void Count2(int n)
        {
            if (n == 0)
                return;

            Console.Write(n);
            
            Count2(--n);

        }


    }
}
