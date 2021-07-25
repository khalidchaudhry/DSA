using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe.Services
{
    public interface IInputProcessor<T>
    {
        T[] Process(T input);

        int[] Transform(T[] input);
    }
}
