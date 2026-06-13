using FdkElevator.DTOS.Auth;
using FdkElevator.Models.Auth;

namespace FdkElevator.Services.IServices
{
    public interface IUser
    {
        Task<string> addUser(User user);

        bool updatePassword(string password, Guid userId);

        List<User> GetUsers(Guid tenantId);

        User GetUserById(Guid id);

        User GetUserByEmail(string email);

        string updateUser(User user);

        string deleteUser(User user);

        string resetPassword(ResetPassword resetPasswordRequest);

        string updateTimeStamp(Guid Id, UpdateTimeStamp uts);
        Task<string> forgotPassword(string email);


        LoginResponse loginUser(string email, string password);

        List<ClientResDTO> getClients();

        Task<ClientSummaryResponse> GetClientByIdAsync(Guid clientId);

        Task<List<ClientSummaryResponse>> GetAllClientsAsync();

        List<User> getUsersByRoles(Role roles);
    }
}
