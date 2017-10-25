namespace Users.Responses
{
    public class LoginResponse
    {
        public bool IsValid { get; set; }
        public string Error { get; set; }
        public string UserName { get; set; }
    }
}