using SplitWise.Factory;
using SplitWise.Services.Interfaces;
using SplitWise.Util;
using System;
using System.Linq;

namespace SplitWise.Services
{
    public class InputProcessor : IInputProcessor
    {
        private readonly SplitStrategyFactory _splitStrategyFactory;
        private readonly ExpenseManager _expenseManager;
        private readonly IBalanceViewer _balanceViewer;
        public InputProcessor(SplitStrategyFactory splitStrategyFactory,
                              ExpenseManager expenseManager,
                              IBalanceViewer balanceViewer)
        {
            _splitStrategyFactory = splitStrategyFactory;
            _expenseManager = expenseManager;
            _balanceViewer = balanceViewer;
        }
        public void Process(string inputLine)
        {
            inputLine = inputLine.ToLower();

            if (inputLine.Contains(Constants.EQUAL_SPLIT_STRATEGY) ||
                inputLine.Contains(Constants.EXACT_SPLIT_STRATEGY) ||
                inputLine.Contains(Constants.PERCENTAGE_SPLIT_STRATEGY)
                )
            {
                var splitStrategy = _splitStrategyFactory.GetSplitStrategy(inputLine);
                var expense = splitStrategy.Split(inputLine);
                _expenseManager.HandleExpense(expense);
            }
            else if (inputLine.Contains(Constants.SHOW))
            {
                if (inputLine.Equals(Constants.SHOW))
                {
                    _balanceViewer.ShowAllUsersBalance();
                }
                else
                {
                    string[] tokens = inputLine.Split(' ');
                    string userId = tokens[1];
                    _balanceViewer.ShowBalance(userId);
                }
            }
            else
            {
                throw new NotSupportedException("Operation not supported");
            }
        }
    }
}
