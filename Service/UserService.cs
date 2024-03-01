using BloggerNews.Dao;
using BloggerNews.Models;
using System.Linq;

namespace BloggerNews.Service
{
    public class UserService
    {
        private ConnectionWithDatabaseDataContext db = new ConnectionWithDatabaseDataContext();

        public UserDao GetUserByUsernameAndPassword (string username, string password)
        {
            User userRequest = db.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (userRequest != null)
            {
                return new UserDao()
                {
                    Id = userRequest.Id,
                    Username = userRequest.Username,
                    Password = userRequest.Password,
                    RoleDescription = userRequest.Role.RoleDescription,
                };
            }
            return null;
        }
    }
}