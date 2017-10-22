using System.Text.RegularExpressions;
using Users.Interfaces;

namespace Users.Implementation
{
    public class Validation : IValidation
    {
        public bool IsEmailValid(string emailAddress)
        {
            var isEmail = Regex.IsMatch(emailAddress, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            return isEmail;
        }

        public bool IsPassWordValid(string password)
        {
            throw new System.NotImplementedException();
        }
    }
}