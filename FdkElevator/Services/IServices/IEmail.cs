namespace FdkElevator.Services.IServices
{
    public interface IEmail
    {
        Task<bool> welcomeEmail(string name, string email, string password);

        Task<bool> resetPassword(string token, string Name, string Email);

        Task<bool> projectEmail(string clientName, string project_name, string clientEmail, string createdDate);

        Task<bool> QuotationEmail(string clientName, string project_name, string clientEmail, string createdDate, string pdfBlobUrl);
    }
}
