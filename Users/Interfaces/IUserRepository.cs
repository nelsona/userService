namespace Users.Interfaces
{
    public interface IUserRepository
    {
        int Add(string email, string password);
        User Find(string email, string password);
    }
}