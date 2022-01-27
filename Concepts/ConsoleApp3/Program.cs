using ConsoleApp3.Robinhood;
using ConsoleApp3.Wayfair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            //RobinhoodScreening robinhood = new RobinhoodScreening();
            //robinhood.ScreeningMain();
            KaratScreening.Run();
        }
    }
}
