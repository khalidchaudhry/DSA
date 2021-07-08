using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //!  https://leetcode.com/discuss/interview-question/object-oriented-design/124738/5-flavors-of-singleton
            var eager =SingletonEagerInitialization.GetInstance();
           



            Console.ReadLine();        
        }
    }
}
