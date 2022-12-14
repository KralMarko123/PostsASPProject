using aspnetserver.Data.Models;
using aspnetserver.Data.Models.Dtos;

namespace aspnetserver.Services
{
    public interface IUsersService
    {
        Task<RequestResult> MapAndCreateUserAsync(UserRegistrationDto userRegistration);
        Task<RequestResult> ValidateUserAsync(UserLoginDto userLogin);
        Task<RequestResult> GetAllUsernamesAsync();
        Task<User> GetUserByUsernameAsync(string username);
        Task<List<string>> GetUserRolesByUsernameAsync(string username);
        Task<string> GenerateEmailConfirmationTokenForUserAsync(User user);
        Task<bool> ConfirmEmailForUserAsync(User user, string token);
    }
}
