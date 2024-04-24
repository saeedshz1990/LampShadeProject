using MailKit.Net.Smtp;
using MimeKit;

namespace _0_FrameWork.Application.Email
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string title, string messageBody, string destination)
        {
            var message = new MimeMessage();

            var from = new MailboxAddress("Saeed", "test@Saeed.com");
            message.From.Add(from);

            var to = new MailboxAddress("User", destination);
            message.To.Add(to);

            message.Subject = title;
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $"<h1>{messageBody}</h1>",
            };

            message.Body = bodyBuilder.ToMessageBody();

            var client = new SmtpClient();
            client.Connect("185.88.152.251", 25, false);// تنظیمات ایمیل باید عوض شود
            client.Authenticate("test@Saeed.com", "Saeed.123456");
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}
