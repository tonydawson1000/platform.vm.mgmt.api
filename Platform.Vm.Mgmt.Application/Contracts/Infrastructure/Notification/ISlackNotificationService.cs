namespace Platform.Vm.Mgmt.Application.Contracts.Infrastructure.Notification
{
    public interface ISlackNotificationService
    {
        Task<bool> SendNotification(Models.Notification.SlackNotification slackNotification);
    }
}