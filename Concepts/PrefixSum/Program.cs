using PrefixSum.GeeksForGeeks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefixSum
{
    class Program
    {
        static void Main(string[] args)
        {

            PrintLeaders printLeaders = new PrintLeaders();
            int[] numbers = new int[] {16, 17, 4, 3, 5, 2  };
            printLeaders.printLeaders(numbers);

            Console.ReadLine();
        }
    }
}
