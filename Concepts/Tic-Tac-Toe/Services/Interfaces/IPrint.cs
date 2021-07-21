using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Services.Interfaces
{
    public interface IPrint
    {
        void Print(string str);
        void Print<T>(T[,] grid);
    }
}
