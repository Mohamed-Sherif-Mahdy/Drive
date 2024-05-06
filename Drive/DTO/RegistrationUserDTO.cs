using System.ComponentModel.DataAnnotations;

namespace Drive.DTO
{
  public class RegistrationUserDTO
  {

    public string Username { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
    [Compare("Password")]
    public string ConfirmationPassword { get; set; }
  }
}
