using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace XCafeProject.Email
{
    //mail adresine mail doğrulama işlemleri ve şifre sıfırlama işlemleri için tanımlandı
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client =new SendGridClient(Options.SendGridKey);
            var mesaj = new SendGridMessage()
            {
                From = new EmailAddress("emirtanta@hotmail.com", "X Cafe"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage
            };

            mesaj.AddTo(new EmailAddress(email));

            try
            {
                return client.SendEmailAsync(mesaj);
            }
            catch (System.Exception)
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
