using System;
using System.Collections.Generic;
using System.Configuration;
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

        public PasswordValidationResponse IsPassWordValid(string password)
        {
            var response = new PasswordValidationResponse {IsValid = true, Reasons = new List<string>()};
            if (password.Length == 0)
            {
                response.IsValid = false;
                response.Reasons.Add("Password is empty.");
                return response;
            }

            if (password.Length >= Convert.ToInt32(ConfigurationManager.AppSettings["MinimumPasswordLength"])) return response;
            
            response.IsValid = false;
            response.Reasons.Add("Password is too short.");

            return response;
        }

        public class PasswordValidationResponse
        {
            public bool IsValid { get; set; }
            public IList<string> Reasons { get; set; }
        }
    }
}