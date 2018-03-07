using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace B4.EE.DellobelI.Domain.Services.Abstract
{
    public interface IEmailService
    {


        //private static readonly Lazy<IEmailService> instance = new Lazy<IEmailService>(() => DependencyService.Get<IEmailService>());

        //public static Lazy<IEmailService> Instance => instance;

        //public abstract bool CanSend { get; }

        Task SendMailAsync(string subject, string body, string mailTo, string naamTo, string mailFrom, string naamFrom);


    }
}
