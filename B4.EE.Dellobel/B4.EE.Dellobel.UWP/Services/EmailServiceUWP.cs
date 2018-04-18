
using B4.EE.DellobelI.Domain.Services.Abstract;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(B4.EE.DellobelI.UWP.Services.EmailServiceUWP))]


namespace B4.EE.DellobelI.UWP.Services
{
    public class EmailServiceUWP : IEmailService
    {
        public  Task SendMailAsync(string subject, string body, string mailTo, string naamTo, string mailFrom, string naamFrom)

        {


            var apiKey = new ApiKey.ApiKey();
            var client = new SendGridClient(apiKey.Key);
            var msg = new SendGridMessage();
            var From = new SendGrid.Helpers.Mail.EmailAddress(mailFrom, naamFrom);
            var To = new SendGrid.Helpers.Mail.EmailAddress(mailTo, naamTo);
            var plainTextContent = body;
            var htmlContent = body;
            msg = MailHelper.CreateSingleEmail(From, To, subject, plainTextContent, htmlContent);

            return client.SendEmailAsync(msg);

        }

    }
}
