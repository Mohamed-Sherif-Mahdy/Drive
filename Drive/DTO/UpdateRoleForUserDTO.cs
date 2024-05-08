using System.ComponentModel.DataAnnotations;

namespace Drive.DTO
{
    public class UpdateRoleForUserDTO
    {
        public string UserId { get; set; }

        [Required]
        public List<string> Role { get; set; } = new List<string>();
    }
}
