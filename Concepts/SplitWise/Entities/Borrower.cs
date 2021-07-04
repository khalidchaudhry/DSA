using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Entities
{
    public class Borrower
    {
        public Borrower(User borrowedBy,double amount)
        {
            BorrowedBy = borrowedBy;
            Amount = amount;
        }

        public User BorrowedBy { get; }
        public double Amount { get; }
    }
}
