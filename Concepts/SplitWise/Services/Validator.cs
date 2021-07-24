using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Services
{
    public class Validator
    {

        public bool IsCountValid(string[] tokens, int count)
        {
            return tokens.Length == count;
        }
    }
}
