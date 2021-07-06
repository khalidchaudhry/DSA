using SplitWise.Entities;
using SplitWise.Services.Interfaces;
using SplitWise.Util;
using System;
using System.Collections.Generic;

namespace SplitWise.Services
{
    public class ExactSplitStrategy : ISplitStrategy
    {
        public Expense Split(string line)
        {
            line = line.ToLower();
            //! u1 1250 2 u2 u3 EXACT 370 880
            //  0    1   2   3  4 5   6     7   8
            string[] tokens = line.Split(' ');
            string spentBy = tokens[0];

            double spentAmount = NumberHelper.RoundToTwoDecimalPlaces(Convert.ToDouble(tokens[1]));
            int nPerson = Convert.ToInt32(tokens[2]);
            string temp = line.Substring(line.IndexOf(tokens[3]));

            string[] expenseTokens = temp.Split(new string[] { Constants.EXACT_SPLIT_STRATEGY }, StringSplitOptions.None);
            string[] userTokens = expenseTokens[0].Split(' ');
            string[] amountTokens = expenseTokens[1].Split(' ');

            //!in case of exact, you need to verify if the total sum of shares is equal to the total amount or not.
            IsValid(amountTokens, spentAmount);

            List<Borrower> borrowers = new List<Borrower>();
            for (int i = 0; i < nPerson; ++i)
            {
                string user = userTokens[i];
                double amount = NumberHelper.RoundToTwoDecimalPlaces(Convert.ToDouble(amountTokens[i+1]));
                Borrower borrower = new Borrower(user, amount);
                borrowers.Add(borrower);
            }

            return new Expense(spentBy, borrowers);
        }

        private void IsValid(string[] amountTokens, double spentAmount)
        {
            double sum = 0;
            for (int i = 1; i < amountTokens.Length; i++)
            {
                string amountToken = amountTokens[i];
                sum += NumberHelper.RoundToTwoDecimalPlaces(Convert.ToDouble(amountToken));
            }
            if (sum > spentAmount)
            {
                throw new InvalidOperationException($"Total shares sum is not equal to total amount spent");
            }
        }
    }
}
