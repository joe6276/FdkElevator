using FdkElevator.Services.IServices;
using MimeKit;

namespace FdkElevator.Services
{
    public class EmailService : IEmail
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration=configuration;
        }
        public async Task<bool> welcomeEmail(string name, string email, string generatedPassword)
        {
            var myemail = _configuration.GetSection("EmailService:Email").Get<string>();
            var password = _configuration.GetSection("EmailService:Password").Get<string>();

            MimeMessage message1 = new MimeMessage();
            message1.From.Add(new MailboxAddress("Welcome Email ", email));

            // Set the recipient's email address
            message1.To.Add(new MailboxAddress(name, email));

            message1.Subject = "Account verified Email";

            var builder = new BodyBuilder();
            string htmlTemplate = await File.ReadAllTextAsync("Templates/welcome.html");
            builder.HtmlBody = htmlTemplate
                .Replace("{name}", name)
                .Replace("{email}", email)
                .Replace("{password}", generatedPassword);

            message1.Body = builder.ToMessageBody();

            var client = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                client.Connect("smtp.gmail.com", 587, false);

                client.Authenticate(myemail, password);

                await client.SendAsync(message1);

                await client.DisconnectAsync(true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> resetPassword(string token, string name, string email)
        {

            var myemail = _configuration.GetSection("EmailService:Email").Get<string>();
            var password = _configuration.GetSection("EmailService:Password").Get<string>();
            var frontend = _configuration.GetSection("EmailService:FrontendURL").Get<string>();

            MimeMessage message1 = new MimeMessage();
            message1.From.Add(new MailboxAddress("Reset Email ", email));

            // Set the recipient's email address
            message1.To.Add(new MailboxAddress(name, email));

            message1.Subject = " Password reset request";

            var builder = new BodyBuilder();
            var resetLink = frontend + "/" + token;
            string htmlTemplate = await File.ReadAllTextAsync("Templates/resetPassword.html");
            builder.HtmlBody = htmlTemplate.Replace("{reset_link}", resetLink);

            message1.Body = builder.ToMessageBody();

            var client = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                client.Connect("smtp.gmail.com", 587, false);

                client.Authenticate(myemail, password);

                await client.SendAsync(message1);

                await client.DisconnectAsync(true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public async Task<bool> projectEmail(string clientName, string project_name, string clientEmail, string createdDate)
        {

            var myemail = _configuration.GetSection("EmailService:Email").Get<string>();
            var password = _configuration.GetSection("EmailService:Password").Get<string>();
            var frontend = _configuration.GetSection("EmailService:FrontendURL").Get<string>();

            MimeMessage message1 = new MimeMessage();
            message1.From.Add(new MailboxAddress("Project Created", myemail));

            message1.To.Add(new MailboxAddress(clientName, clientEmail));

            message1.Subject = "Project Created Successfully!";

            var builder = new BodyBuilder();
            string htmlTemplate = await File.ReadAllTextAsync("Templates/project.html");
            builder.HtmlBody = htmlTemplate
                .Replace("{name}", clientName)
                .Replace("{project_name}", project_name)
                .Replace("{created_date}", createdDate);

            message1.Body = builder.ToMessageBody();

            var client = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                client.Connect("smtp.gmail.com", 587, false);

                client.Authenticate(myemail, password);

                await client.SendAsync(message1);

                await client.DisconnectAsync(true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
