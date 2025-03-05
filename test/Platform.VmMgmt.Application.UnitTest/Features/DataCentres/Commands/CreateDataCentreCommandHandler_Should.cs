using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Platform.Vm.Mgmt.Application.Contracts.Infrastructure.Email;
using Platform.Vm.Mgmt.Application.Contracts.Infrastructure.Notification;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;
using Platform.Vm.Mgmt.Application.Exceptions;
using Platform.Vm.Mgmt.Application.Features.DataCentres.Commands.CreateDataCentre;
using Platform.Vm.Mgmt.Application.Profiles;
using Platform.VmMgmt.Application.UnitTest.Mocks;
using Shouldly;

namespace Platform.VmMgmt.Application.UnitTest.Features.DataCentres.Commands
{
    public class CreateDataCentreCommandHandler_Should
    {
        private readonly Mock<ILogger<CreateDataCentreCommandHandler>> _logger;
        private readonly Mock<IDataCentreRepository> _mockDataCentreRepository;
        private readonly Mock<IEmailService> _mockEmailService;
        private readonly Mock<ISlackNotificationService> _mockSlackNotificationService;
        private readonly IMapper _mapper;

        public CreateDataCentreCommandHandler_Should()
        {
            _logger = new Mock<ILogger<CreateDataCentreCommandHandler>>();

            _mockDataCentreRepository = RepositoryMocks.GetDataCentreRepository();
            _mockEmailService = InfrastructureMocks.GetEmailService();
            _mockSlackNotificationService = InfrastructureMocks.GetSlackNotificationService();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Return_CreateDataCentreCommandResponse_WhenCreateDataCentreRequested()
        {
            var createDataCentreCommand = new CreateDataCentreCommand()
            {
                Name = "Test Data Centre",
                Description = "Test Data Centre Description",
                IsEnabled = true,
                Location = "Test Location"
            };

            var handler = new CreateDataCentreCommandHandler(
                _logger.Object,
                _mapper,
                _mockDataCentreRepository.Object,
                _mockEmailService.Object,
                _mockSlackNotificationService.Object
                );

            var result = await handler.Handle(createDataCentreCommand, CancellationToken.None);

            result.ShouldBeOfType<CreateDataCentreCommandResponse>();
        }

        [Fact]
        public async Task Throw_ValidationException_WhenNameIsEmptyString()
        {
            var createDataCentreCommand = new CreateDataCentreCommand()
            {
                Name = "",
                Description = "Test Data Centre Description",
                IsEnabled = true,
                Location = "Test Location"
            };

            var handler = new CreateDataCentreCommandHandler(
                _logger.Object,
                _mapper,
                _mockDataCentreRepository.Object,
                _mockEmailService.Object,
                _mockSlackNotificationService.Object
                );

            var result = await Should.ThrowAsync<ValidationException>(() => handler.Handle(createDataCentreCommand, CancellationToken.None));
            
            result.ShouldBeOfType<ValidationException>();
        }
    }
}