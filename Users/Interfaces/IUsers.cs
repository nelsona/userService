using Users.Responses;

namespace Users.Interfaces
{
    public interface IUsers
    {
        RegistrationResponse Register(string email, string password);
        LoginResponse Login(string email, string password);
    }
}