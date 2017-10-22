using System;

namespace Users.Interfaces
{
    public interface IValidation
    {
        bool IsEmailValid(string emailAddress);
        bool IsPassWordValid(string password);
    }
}