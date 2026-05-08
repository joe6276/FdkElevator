using FdkElevator.DTOS.Auth;
using FdkElevator.Models.Auth;

namespace FdkElevator.Services.IServices
{
    public interface IUser
    {
        string addUser(User user);

        bool updatePassword(string password, Guid userId);

        List<User> GetUsers();

        User GetUserById(Guid id);

        User GetUserByEmail(string email);

        string updateUser(User user);

        string deleteUser(User user);

        string resetPassword(ResetPassword resetPasswordRequest);

        Task<string> forgotPassword(string email);


        LoginResponse loginUser(string email, string password);

    }
}
