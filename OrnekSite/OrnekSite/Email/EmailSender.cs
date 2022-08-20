using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace OrnekSite.Email
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(Options.SendGridKey);

            var mesaj = new SendGridMessage()
            {
                From = new EmailAddress("emirtanta41@gmail.com", "Emir"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage
            };

            mesaj.AddTo(new EmailAddress(email));

            try
            {
                return client.SendEmailAsync(mesaj);
            }
            catch (Exception)
            {

                throw;
            }

            return null;
        }

        public EmailOptions Options { get; set; }

        public EmailSender(IOptions<EmailOptions> emailOptions)
        {
            Options = emailOptions.Value;
        }
    }
}
