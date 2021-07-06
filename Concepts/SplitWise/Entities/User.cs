
namespace SplitWise.Entities
{
    public class User
    {
        public string UserId { get; }
        public string UserName { get; }
        public string UserEmail { get; }
        public string UserPhone { get; }

        public User(string userId,string userName,string userEmail,string userPhone)
        {
            UserId = userId;
            UserName = userName;
            UserEmail = userEmail;
            UserPhone = userPhone;
        }
    }
}
