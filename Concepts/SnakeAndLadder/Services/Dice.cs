using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadder.Services
{
    public static class Dice
    {
        private static readonly Random _random;
        static Dice()
        {
            _random = new Random(1);
        }

        public static int Roll()
        {
            return _random.Next(7);
        }
    }
}
