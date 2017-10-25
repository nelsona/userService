using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Users.Interfaces;

namespace Users.Implementation
{
    public class UserRepository : IUserRepository
    {
        public int Add(string email, string password)
        {
            using (var context = new UsersContext())
            {
                var user = new User {Email = email, Password = password};
                context.Users.Add(user);
                return context.SaveChanges();
            }
        }

        public User Find(string email, string password)
        {
            using (var context = new UsersContext())
            {
                var user = context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
                return user;
            }
        }
    }
}