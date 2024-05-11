using TeaProduction.Business.Models;

namespace TeaProduction.Business.Interfaces
{
    public interface IEmailInterface
    {
        void SendEmail(EmailMessageModel message);
        Task SendEmailAsync(EmailMessageModel message);
    }
}
