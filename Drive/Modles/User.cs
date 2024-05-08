using Microsoft.AspNetCore.Identity;

namespace Drive.Modles
{
    public class User : IdentityUser
    {
        public ICollection<File> Files { get; set; }
    }
}
