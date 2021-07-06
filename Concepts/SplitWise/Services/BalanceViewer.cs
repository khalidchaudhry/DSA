using SplitWise.Entities;
using SplitWise.Repos.Interfaces;
using SplitWise.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplitWise.Services
{
    public class ConsoleBalanceViewer : IBalanceViewer
    {
        private readonly IUserBalanceRepo _userBalanceRepo;
        public ConsoleBalanceViewer(IUserBalanceRepo userBalanceRepo)
        {
            _userBalanceRepo = userBalanceRepo;
        }

        public void ShowBalance(string userId)
        {
            UserBalance userBalance = _userBalanceRepo.GetUserBalance(userId);
            if (userBalance == null)
            {
                Console.WriteLine($"User with id{userId} does not exist");
                return;
            }

            Dictionary<string, double> giveTo = userBalance.GiveTo;
            StringBuilder output = new StringBuilder();
            if (giveTo.Count == 0)
            {
                output.Append($"{userId} does not owe to anyone");
            }
            else
            {
                output.Append($"{userId} owes to");
                output.AppendLine();

                foreach (var keyValue in giveTo)
                {
                    string uId = keyValue.Key;
                    double amount = keyValue.Value;
                    output.Append($"{uId}:{amount}");
                    output.AppendLine();
                }
            }
            Console.WriteLine(output.ToString());
        }

        public void ShowAllUsersBalance()
        {
            List<UserBalance> allUsers = _userBalanceRepo.GetAllUsersBalance();
            StringBuilder output = new StringBuilder();

            foreach (UserBalance userBalance in allUsers)
            {
                string userId = userBalance.UserId;
                foreach (var keyValue in userBalance.GiveTo)
                {

                    output.Append($"{userId} owes {keyValue.Key}: {keyValue.Value}");
                    output.AppendLine();
                }
            }

            Console.WriteLine(output.ToString());
        }
    }
}
