using SplitWise.Repos.Interfaces;

namespace SplitWise.Services
{
    public class BalanceViewer
    {
        private readonly IUserBalanceRepo _userBalanceRepo;
        public BalanceViewer(IUserBalanceRepo userBalanceRepo)
        {
            _userBalanceRepo = userBalanceRepo;
        }
    }
}
