using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PaycoreFinalProject.Data.Model;
using PaycoreFinalProject.Service.Abstract;
using System.Net;
using System.Net.Mail;

namespace PaycoreFinalProject.Service.Concrete
{
    public class MailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly MailSettings _mailSettings;
        private readonly IRabbitMQService _rabbitMQService;
        public MailService(IConfiguration configuration,IOptions<MailSettings> mailSettings, IRabbitMQService rabbitMQService)
        {
            _configuration = configuration;
            _mailSettings = mailSettings.Value;
            _rabbitMQService = rabbitMQService;
        }

        //public async Task SendEmailAsync(MailRequest mailRequest)
        //{
        //    var email = new MimeMessage();
        //    email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        //    email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
        //    email.Subject = mailRequest.Subject;
        //    var builder = new BodyBuilder();

        //    builder.HtmlBody = mailRequest.Body;
        //    email.Body = builder.ToMessageBody();
        //    using var smtp = new MailKit.Net.Smtp.SmtpClient();
        //    smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        //    smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
        //    await smtp.SendAsync(email);
        //    smtp.Disconnect(true);

        //    try
        //    {
        //        _rabbitMQService.Publish(mailRequest);
        //    }
        //    catch (Exception e)
        //    {

        //        throw new Exception(message: e.Message);
        //    }
        //}
        public SmtpClient GetSmtpClient()
        {
            var smtpClient = new SmtpClient(_configuration["Smtp:Host"])
            {
                Port = int.Parse(_configuration["Smtp:Port"]),
                Credentials = new NetworkCredential(_configuration["Smtp:Email"], _configuration["Smtp:Password"]),
                EnableSsl = true
            };

            return smtpClient;
        }

    }
}
