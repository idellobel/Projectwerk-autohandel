using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using B4.EE.DellobelI.Domain.Services.Abstract;
using SendGrid;
using SendGrid.Helpers.Mail;
using Xamarin.Forms;

[assembly: Dependency(typeof(B4.EE.DellobelI.Droid.Services.EmailServiceDroid))]


namespace B4.EE.DellobelI.Droid.Services
{
    public class EmailServiceDroid : IEmailService
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
  