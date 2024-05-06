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
    private readonly RoleManager<IdentityRole> _roleManager;
    public AuthService(UserManager<User> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
    {
      _userManager = userManager;

      _configuration = configuration;
      _roleManager = roleManager;
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

    private async Task<JwtSecurityToken> CreateJwtToken(User user)
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
    public async Task<RegistrationOutPut> LoginUser(LoginDTO user)
    {
      if (await _userManager.FindByEmailAsync(user.Email) is null)
      {
        return new RegistrationOutPut { ErrorMessage = "The Email is Not Registrated Yet.." };
      }
      User existingUser = await _userManager.FindByEmailAsync(user.Email);
      bool isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);
      if (!isCorrect)
      {
        return new RegistrationOutPut { ErrorMessage = "Invalid Password" };
      }
      var JwtSecurityToken = await CreateJwtToken(existingUser);
      return new RegistrationOutPut
      {
        Username = existingUser.UserName,
        Email = existingUser.Email,
        IsAuthenticated = true,
        Roles = (List<string>)await _userManager.GetRolesAsync(existingUser),
        Token = new JwtSecurityTokenHandler().WriteToken(JwtSecurityToken),
        ExpirationOn = JwtSecurityToken.ValidTo
      };


    }

    public async Task<RegistrationOutPut> LogoutUser(LoginDTO user)
    {
      //remove token 
      await _userManager.RemoveAuthenticationTokenAsync(_userManager.FindByEmailAsync(user.Email).Result, "JWT", "Token");
      return new RegistrationOutPut { ErrorMessage = "Token Removed" };
    }

    public async Task<string> AssignRole(UserToRoleDTO user)
    {
      var ExistingUser = await _userManager.FindByIdAsync(user.UserId);

      if (ExistingUser is null)
      {
        return "There is no user by this ID";
      }
      if (await _roleManager.FindByNameAsync(user.Role) is null)
      {
        return "There is no role by this name";
      }
      if (await _userManager.IsInRoleAsync(ExistingUser, user.Role))
      {
        return "User already has this role";
      }
      await _userManager.AddToRoleAsync(ExistingUser, user.Role);
      return "Role Assigned Successfully";
    }
    //public async Task<string> UpdateRole(UpdateRoleForUserDTO user)
    //{



    //}

    public async Task<string> DeleteRole(UserToRoleDTO user)
    {
      var ExistingUser = await _userManager.FindByIdAsync(user.UserId);
      if (ExistingUser is null)
      {
        return "There is no user by this ID";
      }
      if (await _roleManager.FindByNameAsync(user.Role) is null)
      {
        return "There is no role by this name";
      }
      if (!await _userManager.IsInRoleAsync(ExistingUser, user.Role))
      {
        return "User does not have this role";
      }
      await _userManager.RemoveFromRoleAsync(ExistingUser, user.Role);
      return "Role Removed Successfully";

    }
    public async Task<string> GetRoles(string userId)
    {
      var ExistingUser = await _userManager.FindByIdAsync(userId);
      if (ExistingUser is null)
      {
        return "There is no user by this ID";
      }
      var roles = await _userManager.GetRolesAsync(ExistingUser);
      return string.Join(",", roles);
    }
  }
}
