using HR.Leave.Management.Application.Model;

namespace HR.Leave.Management.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}