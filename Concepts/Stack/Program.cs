﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {

            ArithematicExpressionEval postfix = new ArithematicExpressionEval();
            postfix.ArithematicExpressionEvalMain();
            Console.ReadLine();


        }
    }
}
