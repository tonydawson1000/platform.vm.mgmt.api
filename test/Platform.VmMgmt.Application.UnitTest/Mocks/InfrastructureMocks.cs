using Moq;
using Platform.Vm.Mgmt.Application.Contracts.Infrastructure.Email;
using Platform.Vm.Mgmt.Application.Contracts.Infrastructure.Notification;

namespace Platform.VmMgmt.Application.UnitTest.Mocks
{
    public class InfrastructureMocks
    {
        public static Mock<IEmailService> GetEmailService()
        {
            var email = new Vm.Mgmt.Application.Models.Email.Email
            {
                To = "test@test.com",
                Subject = "Email Testing",
                Body = "Test Email ..."
            };

            var mockEmailService = new Mock<IEmailService>();

            mockEmailService.Setup(repo => repo.SendEmail(email))
                .ReturnsAsync(true);

            return mockEmailService;
        }

        public static Mock<ISlackNotificationService> GetSlackNotificationService()
        {
            var slackNotification = new Vm.Mgmt.Application.Models.Notification.SlackNotification
            {
                Channel = "#test",
                Text = "Test Slack Message"
            };

            var mockSlackNotificationService = new Mock<ISlackNotificationService>();

            mockSlackNotificationService.Setup(repo => repo.SendNotification(slackNotification))
                .ReturnsAsync(true);

            return mockSlackNotificationService;
        }
    }
}