using SplitWise.Entities;
using SplitWise.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Repos
{
    public class MySqlUserRepo : IUserBalanceRepo
    {
        public void AddExpense(Expense expense)
        {
            throw new NotImplementedException();
        }

        public List<UserBalance> GetAllUsersBalance()
        {
            throw new NotImplementedException();
        }

        public UserBalance GetUserBalance(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
