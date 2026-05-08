using FdkElevator.Models.Auth;

namespace FdkElevator.Services.IServices
{
    public interface IJwt
    {
        string generateToken(User user);
    }
}
