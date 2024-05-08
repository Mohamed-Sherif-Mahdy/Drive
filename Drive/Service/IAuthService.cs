using Drive.DTO;

namespace Drive.Service
{
    public interface IAuthService
    {
        public Task<RegistrationOutPut> RegisterUser(RegistrationUserDTO user);
        public Task<RegistrationOutPut> LoginUser(LoginDTO user);
        public Task<RegistrationOutPut> LogoutUser(LoginDTO user);
        public Task<string> AssignRole(UserToRoleDTO user);

        // public Task<string> UpdateRole(UpdateRoleForUserDTO user);
        public Task<string> DeleteRole(UserToRoleDTO user);
        public Task<string> GetRoles(string userId);
    }
}
