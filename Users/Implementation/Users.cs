using System;
using System.Collections.Generic;
using System.Linq;
using Users.Implementation;
using Users.Interfaces;
using Users.Responses;

namespace Users
{
    public class Users : IUsers
    {
        private readonly IValidation validation;
        private readonly IUserRepository repository;

        public Users(IValidation validation, IUserRepository repository)
        {
            this.validation = validation;
            this.repository = repository;
        }
        
        public RegistrationResponse Register(string email, string password)
        {
            var response = new RegistrationResponse { IsValid = true };
            
            var isEmailValid = validation.IsEmailValid(email);
            if (!isEmailValid)
            {
                response.IsValid = false;
                response.Errors = new List<string> {"Email is invalid"};
                return response;
            }
            
            var isPasswordValid = validation.IsPassWordValid(password);
            if (!isPasswordValid.IsValid)
            {
                response.IsValid = false;
                response.Errors = isPasswordValid.Reasons.ToList();
                return response;
            }

            response.UserName = email;

            repository.Add(email, password);
            
            return response;
        }

        public LoginResponse Login(string email, string password)
        {
            var response = new LoginResponse { IsValid = true };

            var user = repository.Find(email, password);

            if (user == null)
            {
                response.IsValid = false;
                response.Error = "No user found for these details";
                return response;
            }
            
            response.UserName = user.Email;
            return response;
        }
    }
}