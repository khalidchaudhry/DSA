using SplitWise.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Services
{
    public class Driver
    {
        private readonly IInputProcessor _inputProcessor;
        public Driver(IInputProcessor inputProcessor)
        {
            _inputProcessor = inputProcessor;
        }
        public void Drive()
        {
            Console.WriteLine("Press enter to complete the input");
            string input = Console.ReadLine();
            _inputProcessor.Process(input);

        }


    }
}
