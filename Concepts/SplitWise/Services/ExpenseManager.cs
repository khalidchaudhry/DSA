using SplitWise.Entities;
using SplitWise.Repos.Interfaces;
using SplitWise.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Services
{
    public class ExpenseManager
    {
        private readonly IUserBalanceRepo _userBalanceRepo;
        public ExpenseManager(IUserBalanceRepo userBalanceRepo)
        {
            _userBalanceRepo = userBalanceRepo;

        }
        public void HandleExpense(Expense expense)
        {
            _userBalanceRepo.AddExpense(expense);
        }

    }
}
