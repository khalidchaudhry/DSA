
using System.Collections.Generic;

namespace SplitWise.Entities
{
    public class UserBalance
    {
        public User User { get; }
        public Dictionary<User, double> TakenFrom { get; }
        public Dictionary<User, double> GivenTo { get; }

        public void ShowBalance()
        {

        }

    }
}
