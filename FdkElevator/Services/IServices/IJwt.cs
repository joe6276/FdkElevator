using FdkElevator.Models.Auth;

namespace FdkElevator.Services.IServices
{
    public interface IJwt
    {
        string generateToken(User user);

        string generateTokenSupplier(Guid Id, string name, string email);
    }
}
