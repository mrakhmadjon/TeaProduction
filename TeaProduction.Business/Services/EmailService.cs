using MailKit.Net.Smtp;
using MimeKit;
using TeaProduction.Business.Interfaces;
using TeaProduction.Business.Models;

namespace TeaProduction.Business.Services
{
    public class EmailService : IEmailInterface
    {
        private readonly ILoggerInterface loggerInterface;
        private readonly EmailConfigurationModel emailConfigurationModel;

        public EmailService(ILoggerInterface loggerInterface,
            EmailConfigurationModel emailConfigurationModel)
        {
            this.loggerInterface = loggerInterface;
            this.emailConfigurationModel = emailConfigurationModel;
        }
        public void SendEmail(EmailMessageModel message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
        }

        public async Task SendEmailAsync(EmailMessageModel message)
        {
            var mailMessage = CreateEmailMessage(message);

            await SendAsync(mailMessage);
        }
        private MimeMessage CreateEmailMessage(EmailMessageModel message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(emailConfigurationModel.From, emailConfigurationModel.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h2 style='color:red;'>{0}</h2>", message.Content) };

            if (message.Attachments != null && message.Attachments.Any())
            {
                byte[] fileBytes;
                foreach (var attachment in message.Attachments)
                {
                    using (var ms = new MemoryStream())
                    {
                        attachment.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }

                    bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
                }
            }

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(emailConfigurationModel.SmtpServer, emailConfigurationModel.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(emailConfigurationModel.UserName, emailConfigurationModel.Password);

                    client.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    loggerInterface.Log(ex, "Error in sending email !!!");

                }
                finally
                {
                    loggerInterface.Log("Email Successfully send", Enums.LogLevel.Information);
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(emailConfigurationModel.SmtpServer, emailConfigurationModel.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(emailConfigurationModel.UserName, emailConfigurationModel.Password);

                    await client.SendAsync(mailMessage);
                }
                catch
                {
                    loggerInterface.Log("Error in sending email !!!", Enums.LogLevel.Error);
                }
                finally
                {
                    loggerInterface.Log("Email Successfully send", Enums.LogLevel.Information);
                    await client.DisconnectAsync(true);
                    client.Dispose();

                }
            }
        }
    }
}
