using Microsoft.Extensions.Options;
using Platform.Vm.Mgmt.Application.Contracts.Infrastructure.Notification;
using Platform.Vm.Mgmt.Application.Models.Notification;

namespace Platform.Vm.Mgmt.Infrastructure.Notification
{
    public class SlackNotificationService : ISlackNotificationService
    {
        public SlackSettings _slackSettings { get; }

        public SlackNotificationService(IOptions<SlackSettings> slackSettings)
        {
            _slackSettings = slackSettings.Value;
        }

        public Task<bool> SendNotification(Application.Models.Notification.SlackNotification slackNotification)
        {
            throw new NotImplementedException();
        }
    }
}