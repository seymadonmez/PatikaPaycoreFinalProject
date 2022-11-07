using System.Net.Mail;

namespace PaycoreFinalProject.Service.Abstract
{
    public interface IEmailService
    {
        SmtpClient GetSmtpClient();
    }
}
