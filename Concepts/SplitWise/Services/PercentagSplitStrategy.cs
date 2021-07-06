using SplitWise.Entities;
using SplitWise.Services.Interfaces;
using SplitWise.Util;
using System;
using System.Collections.Generic;

namespace SplitWise.Services
{
    public class PercentagSplitStrategy : ISplitStrategy
    {
        //EXPENSE u4 1200 4 u1 u2 u3 u4 PERCENT 40 20 20 20
        public Expense Split(string line)
        {
            //The percent and amount provided could have decimals upto two decimal places.
            //In case of percent, you need to verify if the total sum of percentage shares is 100 or not.
            line = line.ToLower();

            string[] tokens = line.Split(' ');
            string spentBy = tokens[1];

            double spentAmount = NumberHelper.RoundToTwoDecimalPlaces(Convert.ToDouble(tokens[2]));
            int nPerson = Convert.ToInt32(tokens[3]);
            string temp = line.Substring(line.IndexOf(tokens[4]));

            string[] expenseTokens = temp.Split(Constants.EXACT_SPLIT_STRATEGY.ToCharArray());
            string[] borrowerTokens = expenseTokens[0].Split(' ');
            string[] percentageTokens = expenseTokens[1].Split(' ');

            //!in case of exact, you need to verify if the total sum of shares is equal to the total amount or not.
            IsValid(percentageTokens);

            List<Borrower> borrowers = new List<Borrower>();
            for (int i = 0; i < nPerson; ++i)
            {
                string user = borrowerTokens[i];
                double amount = NumberHelper.RoundToTwoDecimalPlaces(Convert.ToDouble(percentageTokens[i]));
                Borrower borrower = new Borrower(user, amount);
                borrowers.Add(borrower);
            }
            return new Expense(spentBy, borrowers);
        }
        private void IsValid(string[] percentageTokens)
        {
            double sum = 0;
            foreach (string amountToken in percentageTokens)
            {
                sum += NumberHelper.RoundToTwoDecimalPlaces(Convert.ToDouble(amountToken));
            }
            if (sum != 100)
            {
                throw new InvalidOperationException($"Total shares percentage is not equal to total percentage");
            }
        }
    }
}
