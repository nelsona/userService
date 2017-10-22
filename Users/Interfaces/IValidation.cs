using Users.Implementation;

namespace Users.Interfaces
{
    public interface IValidation
    {
        bool IsEmailValid(string emailAddress);
        Validation.PasswordValidationResponse IsPassWordValid(string password);
    }
}