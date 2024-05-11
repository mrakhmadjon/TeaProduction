using TeaProduction.Business.Interfaces;
using TeaProduction.Business.Models;

namespace TeaProduction.Business.Services
{
    public class EmailService : IEmailInterface
    {
        private readonly ILoggerInterface loggerInterface;

        public EmailService(ILoggerInterface loggerInterface)
        {
            this.loggerInterface = loggerInterface;
        }
        public void SendEmail(EmailMessageModel message)
        {
            throw new NotImplementedException();
        }

        public Task SendEmailAsync(EmailMessageModel message)
        {
            throw new NotImplementedException();
        }
    }
}
