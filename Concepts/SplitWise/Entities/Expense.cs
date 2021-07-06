using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Entities
{
    public class Expense
    {
        public string SpendBy { get; }
        public double Amount { get; }
        //! Why List type is not user? 
        public List<Borrower> Borrowers { get; }
        public Expense(string spendBy, List<Borrower> borrowers)
        {
            SpendBy = spendBy;
            Borrowers = borrowers;
        }
    }
}
