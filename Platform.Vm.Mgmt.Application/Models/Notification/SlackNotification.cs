namespace Platform.Vm.Mgmt.Application.Models.Notification
{
    public class SlackNotification
    {
        public string Channel { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }
}