using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
              Requirements 
              1. 10 people in group 
              2. Equal, Exact and percentage strategy 
              3. Capability for user what they owe and what others owe to them 
              Entities 
              1. User
                    string Name
                    string PhoneNumber
              2. Expense
                    string Name
                    string: Description
                    User: SpendBy
                    List<Borrowers> BowrowList
              3. UserBalance
                    User    
                    Dictionary<User,amount> TakeFrom
                    Dictionary<User,amount> GiveTo 

              4. Borrower 
                   User BorrowedBy
                   double amount
              //Actions on entities 
                  -CreateExpense
                  -CostSplit
                  -ShowBalance
              // System Flow
                 -- Create expense ---> Split ---> 
             // Services
                 -- Driver
                     --InputFromUser
                     
                  --InputProcessor
                      --Process(string inputLine)
                        //! Expense dinner Equal u2,u3,u4
                      --Validate() 
                 -- ExpenseManager
                          --Coordination
                          -- Perform Split  
                          --HandleExpense
                  --BalanceViewer
                           



             */


        }
    }
}
