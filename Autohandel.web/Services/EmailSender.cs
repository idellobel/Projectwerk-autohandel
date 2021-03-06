﻿using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Autohandel.web.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            //Key was removed for safety
            string apiKey = "";
            return Execute(apiKey, subject, message, email);
        }

        //Send email with SendGrid
        private Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("ivan.dellobel@gmail.com", "Auto Vandenheede"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            return client.SendEmailAsync(msg);
        }
    }
}
