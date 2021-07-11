using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe.Services
{
    public interface IInputProcessor<T>
    {
        T[] TransformToArray(T input);

        int[] TransformToArray(T[] input);

        char TransformToChar(string input);
    }
}
