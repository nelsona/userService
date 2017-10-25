using System.Collections.Generic;

namespace Users.Responses
{
    public class RegistrationResponse
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; }
        public string UserName { get; set; }
    }
}