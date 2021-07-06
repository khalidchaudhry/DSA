
using System.Collections.Generic;

namespace SplitWise.Entities
{
    public class UserBalance
    {
        //! does it make sense to make fields as public vs private ? What is the criteria
        public string UserId { get; }        
        public Dictionary<string, double> TakeFrom { get; }=new Dictionary<string, double>();
        public Dictionary<string, double> GiveTo { get; }= new Dictionary<string, double>();

        public UserBalance(string userId)
        {
            UserId = userId; 
        }
        
        public void UpdateGiveTo(string userId, double amount)
        {
            if (!GiveTo.ContainsKey(userId))
            {
                GiveTo.Add(userId, 0);
            }
            GiveTo[userId] += amount;
        }

        public void UpdateTakeFrom(string userId, double amount)
        {
            if (!TakeFrom.ContainsKey(userId))
            {
                TakeFrom.Add(userId, 0);
            }
            TakeFrom[userId] += amount;

        }



    }
}
