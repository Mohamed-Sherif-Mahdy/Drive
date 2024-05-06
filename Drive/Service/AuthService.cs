using Drive.DTO;
using Drive.Modles;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Drive.Service
{
  public class AuthService : IAuthService
  {
    private readonly UserManager<User> _userManager;

    private readonly IConfiguration _configuration;
    public AuthService(UserManager<User> userManager, IConfiguration configuration)
    {
      _userManager = userManager;

      _configuration = configuration;
    }
    public async Task<RegistrationOutPut> RegisterUser(RegistrationUserDTO user)
    {
      if (await _userManager.FindByEmailAsync(user.Email) is not null)
      {
        return new RegistrationOutPut { ErrorMessage = "Email already exists" };
      }
      if (await _userManager.FindByNameAsync(user.Username) is not null)
      {
        return new RegistrationOutPut { ErrorMessage = "Username already exists" };
      }
      User newUser = new User
      {
        UserName = user.Username,
        Email = user.Email
      };
      IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);
      if (!result.Succeeded)
      {
        List<string> ListOfErrors = result.Errors.Select(e => e.Description).ToList();
        string errors = string.Join(",", ListOfErrors);

        return new RegistrationOutPut { ErrorMessage = errors };


      }
      await _userManager.AddToRoleAsync(newUser, "User");

      var JwtSecurityToken = await CreateJwtToken(newUser);

      return new RegistrationOutPut
      {
        Username = newUser.UserName,
        Email = newUser.Email,
        IsAuthenticated = true,
        Roles = new List<string>() { "User" },
        Token = new JwtSecurityTokenHandler().WriteToken(JwtSecurityToken),
        ExpirationOn = JwtSecurityToken.ValidTo
      };
    }

    public async Task<JwtSecurityToken> CreateJwtToken(User user)
    {
      var userClaims = await _userManager.GetClaimsAsync(user);
      var roles = await _userManager.GetRolesAsync(user);
      var roleClaims = roles.Select(r => new Claim("roles", r));
      var claims = new[]
      {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim("uid", user.Id)
      }
      .Union(userClaims)
      .Union(roleClaims);
      IConfigurationSection jwtSection = _configuration.GetSection("JWT");
      var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection["Key"]));
      var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
      var jwtSecurityToken =
       new JwtSecurityToken(
       issuer: jwtSection["Issuer"],
       audience: jwtSection["Audience"],
       claims: claims,
       expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSection["DurationInMinutes"])),
       signingCredentials: signingCredentials
       );
      return jwtSecurityToken;
    }
  }
}
