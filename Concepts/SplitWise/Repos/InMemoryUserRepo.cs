using SplitWise.Entities;
using SplitWise.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Repos
{

    class InMemoryUserRepo : IUserBalanceRepo
    {

        public Dictionary<string, UserBalance> _inMemoryStore;
        public InMemoryUserRepo()
        {
            _inMemoryStore = new Dictionary<string, UserBalance>();
        }
        public void AddExpense(Expense expense)
        {
            string spendBy = expense.SpendBy;
            List<Borrower> borrowers = expense.Borrowers;

            if (!_inMemoryStore.ContainsKey(spendBy))
            {
                _inMemoryStore.Add(spendBy, new UserBalance(spendBy));
            }

            foreach (Borrower borrower in borrowers)
            {
                string borrowedBy = borrower.BorrowedBy;
                if (!_inMemoryStore.ContainsKey(borrowedBy))
                {
                    _inMemoryStore.Add(borrowedBy, new UserBalance(borrowedBy));
                }
                _inMemoryStore[borrowedBy].UpdateGiveTo(spendBy, borrower.Amount);
                _inMemoryStore[spendBy].UpdateTakeFrom(borrowedBy, borrower.Amount);
            }
        }

        public UserBalance GetUserBalance(string userId)
        {
            if (_inMemoryStore.ContainsKey(userId))
                return _inMemoryStore[userId];
            //! is it considered as a good practice ?
            return null;
            
        }
        public List<UserBalance> GetAllUsersBalance()
        {
            List<UserBalance> allUserBalances = new List<UserBalance>();
            foreach (var keyValue in _inMemoryStore)
            {
                allUserBalances.Add(keyValue.Value);
            }
            return allUserBalances;
        }

    }
}
