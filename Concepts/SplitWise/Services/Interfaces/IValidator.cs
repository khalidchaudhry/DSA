using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Services.Interfaces
{
    public interface IValidator
    {
        bool IsCountValid(string[] tokens, int count);

    }
}
