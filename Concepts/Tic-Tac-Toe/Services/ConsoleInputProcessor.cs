using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe.Services
{
    public class ConsoleInputProcessor : IInputProcessor<string>
    {
        GameManager _gameManager;
        public ConsoleInputProcessor(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public string[] TransformToArray(string input)
        {
            string[] tokens = input.Split(' ');
            return tokens;
        }

        public int[] TransformToArray(string[] input)
        {
            int n = input.Length;
            int[] result = new int[n];
            for (int i = 0; i < n; ++i)
            {
                result[i] = Convert.ToInt32(input[i]);
            }
            return result;
        }

        public char TransformToChar(string input)
        {
            return Convert.ToChar(input);
        }
    }
}
