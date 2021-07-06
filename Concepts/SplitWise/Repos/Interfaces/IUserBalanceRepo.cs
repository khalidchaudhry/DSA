
using SplitWise.Entities;
using System.Collections.Generic;

namespace SplitWise.Repos.Interfaces
{
    public interface IUserBalanceRepo
    {

        void AddExpense(Expense expense);
        UserBalance GetUserBalance(string userId);
        List<UserBalance> GetAllUsersBalance();

    }
}
