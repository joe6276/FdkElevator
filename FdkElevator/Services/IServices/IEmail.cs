namespace FdkElevator.Services.IServices
{
    public interface IEmail
    {
        Task<bool> welcomeEmail(string name, string email, string password);

        Task<bool> resetPassword(string token, string Name, string Email);
    }
}
