using SplitWise.Entities;
using SplitWise.Services.Interfaces;
using SplitWise.Util;
using System;
using System.Collections.Generic;

namespace SplitWise.Services
{
    public class PercentagSplitStrategy : ISplitStrategy
    {
        //u4 1200 4 u1 u2 u3 u4 PERCENT 40 20 20 20
        // 0   1  2  3  4  5  6  7      8   9 10 11
        public Expense Split(string line)
        {
            //The percent and amount provided could have decimals upto two decimal places.
            //In case of percent, you need to verify if the total sum of percentage shares is 100 or not.
            line = line.ToLower();

            string[] tokens = line.Split(' ');
            string spentBy = tokens[0];

            double spentAmount = NumberHelper.RoundToTwoDecimalPlaces(Convert.ToDouble(tokens[1]));
            int nPerson = Convert.ToInt32(tokens[2]);
            string temp = line.Substring(line.IndexOf(tokens[3]));

            string[] expenseTokens = temp.Split(new string[] { Constants.PERCENTAGE_SPLIT_STRATEGY }, StringSplitOptions.None);
            string[] borrowerTokens = expenseTokens[0].Split(' ');
            string[] percentageTokens = expenseTokens[1].Split(' ');

            //!in case of exact, you need to verify if the total sum of shares is equal to the total amount or not.
            IsValid(percentageTokens);

            List<Borrower> borrowers = new List<Borrower>();
            for (int i = 1; i < nPerson; ++i)
            {
                string user = borrowerTokens[i];
                double percent = NumberHelper.RoundToTwoDecimalPlaces(Convert.ToDouble(percentageTokens[i+1]));
                double amount = NumberHelper.RoundToTwoDecimalPlaces((percent / 100) * spentAmount);
                Borrower borrower = new Borrower(user, amount);
                borrowers.Add(borrower);
            }
            return new Expense(spentBy, borrowers);
        }
        private void IsValid(string[] percentageTokens)
        {
            double sum = 0;
            for (int i = 1; i < percentageTokens.Length; i++)
            {
                string amountToken = percentageTokens[i];
                sum += NumberHelper.RoundToTwoDecimalPlaces(Convert.ToDouble(amountToken));
            }
            if (sum != 100)
            {
                throw new InvalidOperationException($"Total shares percentage is not equal to total percentage");
            }
        }
    }
}
