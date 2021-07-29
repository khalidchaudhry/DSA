using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadder.Services
{
    public class Dice
    {
        private Random _random;
        public int MaxValue { get; }
        public Dice(int maxValue)
        {
            _random = new Random();
            MaxValue = maxValue;
        }
        public int Roll()
        {
            return _random.Next(1,MaxValue+1);
        }

    }
}
