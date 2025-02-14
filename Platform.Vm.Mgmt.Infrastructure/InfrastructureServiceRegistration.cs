using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Platform.Vm.Mgmt.Application.Contracts.Infrastructure.Email;
using Platform.Vm.Mgmt.Application.Contracts.Infrastructure.Notification;
using Platform.Vm.Mgmt.Application.Models.Email;
using Platform.Vm.Mgmt.Application.Models.Notification;
using Platform.Vm.Mgmt.Infrastructure.Email;
using Platform.Vm.Mgmt.Infrastructure.Notification;

namespace Platform.Vm.Mgmt.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.Configure<SlackSettings>(configuration.GetSection("SlackSettings"));

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ISlackNotificationService, SlackNotificationService>();

            return services;
        }
    }
}