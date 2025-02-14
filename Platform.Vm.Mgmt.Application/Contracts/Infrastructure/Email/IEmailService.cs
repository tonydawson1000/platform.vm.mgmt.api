namespace Platform.Vm.Mgmt.Application.Contracts.Infrastructure.Email
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Models.Email.Email email);
    }
}