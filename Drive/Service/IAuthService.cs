using Drive.DTO;
using Drive.Modles;
using System.IdentityModel.Tokens.Jwt;

namespace Drive.Service
{
  public interface IAuthService
  {
    public Task<RegistrationOutPut> RegisterUser(RegistrationUserDTO user);
    public Task<JwtSecurityToken> CreateJwtToken(User user);
  }
}
