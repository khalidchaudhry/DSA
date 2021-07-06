
using SplitWise.Entities;
using SplitWise.Services.Interfaces;
using SplitWise.Util;
using System;
using System.Collections.Generic;

namespace SplitWise.Services
{
    public class EqualSplitStrategy : ISplitStrategy
    {
        public Expense Split(string line)
        {
            //Input: u1 1000 4 u1 u2 u3 u4 EQUAL
            line = line.ToLower();
            string[] tokens = line.Split(' ');
            string spentBy = tokens[0];
            double spentAmount = NumberHelper.RoundToTwoDecimalPlaces(Convert.ToDouble(tokens[1]));
            int nPerson = Convert.ToInt32(tokens[2]);

            string temp = line.Substring(line.LastIndexOf(tokens[3]));

            string[] expenseTokens = temp.Split(new string[] { Constants.EQUAL_SPLIT_STRATEGY }, StringSplitOptions.None);
            string[] borrowersTokens = expenseTokens[0].Split(' ');
            double amountPerUser = NumberHelper.RoundToTwoDecimalPlaces(spentAmount / nPerson);

            List<Borrower> borrowers = new List<Borrower>();
            for (int i = 1; i < borrowersTokens.Length - 1; i++)
            {
                string borrowerToken = borrowersTokens[i];
                string user = borrowerToken;
                double amount = amountPerUser;
                Borrower borrower = new Borrower(user, amount);
                borrowers.Add(borrower);
            }
            return new Expense(spentBy, borrowers);
        }
    }
}
