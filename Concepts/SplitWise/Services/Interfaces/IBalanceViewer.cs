using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Services.Interfaces
{
    public interface IBalanceViewer
    {
        void ShowBalance(string userId);
        void ShowAllUsersBalance();

    }
}
