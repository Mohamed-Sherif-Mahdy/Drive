namespace Drive.DTO
{
    public class RegistrationOutPut
    {
        public string Username { get; set; }
        public bool IsAuthenticated { get; set; } = false;
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationOn { get; set; }
        public string ErrorMessage { get; set; }
        public string UserId { get; set; }
    }
}
