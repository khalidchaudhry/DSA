using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Entities
{
    public class User
    {
        public int UserId { get; }
        public string UserName { get; }
        public string UserEmail { get; }

        public User(int userId,string userName,string userEmail)
        {
            UserId = userId;
            UserName = userName;
            UserEmail = userEmail;
        }


    }
}
