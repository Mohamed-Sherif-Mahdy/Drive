using System.ComponentModel.DataAnnotations;

namespace Drive.DTO
{
    public class RegistrationUserDTO
    {
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmationPassword { get; set; }
    }
}
