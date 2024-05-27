using MimeKit;
using MailKit.Net.Smtp;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            using var emailMessage = new MimeMessage();
 
            emailMessage.From.Add(new MailboxAddress("МФЦ РУТ(МИИТ)", "mr.dima17@list.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using var client = new SmtpClient();
            
            await client.ConnectAsync("smtp.mail.ru", 25, false);
            await client.AuthenticateAsync("mr.dima17@list.ru", "1wreZzi2S6ibHKZLd5KS");
            await client.SendAsync(emailMessage);
 
            await client.DisconnectAsync(true);
        }
    }
}