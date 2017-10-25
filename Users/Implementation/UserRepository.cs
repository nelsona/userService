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
                // TODO: Storing the password in plain text is bad. This would need to be stored as a hashed value.
                var user = new User {Email = email, Password = password};
                context.Users.Add(user);
                return context.SaveChanges();
            }
        }

        public User Find(string email, string password)
        {
            using (var context = new UsersContext())
            {
                // TODO: This needs to be reworked to use a hashed password for the check.
                var user = context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
                return user;
            }
        }
    }
}