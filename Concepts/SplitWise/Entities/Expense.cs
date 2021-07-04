using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Entities
{
    public class Expense
    {
        public string Name { get; }
        public string Description { get; }
        public User SpendBy { get; }
        //! Why List type is not user? 
        List<Borrower> Borrowers { get; }
        public Expense(string name, string description, User spendBy, List<Borrower> borrowers)
        {
            Name = name;
            Description = description;
            SpendBy = spendBy;
            Borrowers = borrowers;
        }
        public void CreateExpense()
        {


        }
    }
}
