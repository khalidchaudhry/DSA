using SnakeAndLadder.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadder.Services
{
    public class ApplicationRunner
    {
        private readonly IInputProcessor _inputProcessor;
        public ApplicationRunner(IInputProcessor inputProcessor)
        {
            _inputProcessor = inputProcessor;
        }
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Press enter to complete the input");
                string input = Console.ReadLine();
                _inputProcessor.Process(input);
            }
        }


    }
}
