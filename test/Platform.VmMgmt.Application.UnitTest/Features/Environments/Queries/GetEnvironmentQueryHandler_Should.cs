using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;
using Platform.Vm.Mgmt.Application.Exceptions;
using Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentDetail;
using Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentsList;
using Platform.Vm.Mgmt.Application.Profiles;
using Platform.VmMgmt.Application.UnitTest.Mocks;
using Shouldly;

namespace Platform.VmMgmt.Application.UnitTest.Features.Environments.Queries
{
    public class GetEnvironmentQueryHandler_Should
    {
        private readonly Mock<ILogger<GetEnvironmentDetailQueryHandler>> _logger;
        private readonly Mock<IDataCentreRepository> _mockDataCentreRepository;
        private readonly Mock<IAsyncRepository<Vm.Mgmt.Domain.Entities.Environment>> _mockEnvironmentRepository;
        private readonly Mock<IAsyncRepository<Vm.Mgmt.Domain.Entities.Vlan>> _mockVlanRepository;
        private readonly IMapper _mapper;

        public GetEnvironmentQueryHandler_Should()
        {
            _logger = new Mock<ILogger<GetEnvironmentDetailQueryHandler>>();

            _mockDataCentreRepository = RepositoryMocks.GetDataCentreRepository();
            _mockEnvironmentRepository = RepositoryMocks.GetEnvironmentRepository();
            _mockVlanRepository = RepositoryMocks.GetVlanRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Return_EnvironmentListQueryResponse_WhenListQueryRequested()
        {
            var handler = new GetEnvironmentsListQueryHandler(
                _mapper,
                _mockEnvironmentRepository.Object);

            var result = await handler.Handle(new GetEnvironmentsListQuery(), CancellationToken.None);
            
            result.ShouldBeOfType<GetEnvironmentsListQueryResponse>();
        }

        [Fact]
        public async Task Throw_NotFoundException_WhenIdDoesntExist()
        {
            var handler = new GetEnvironmentDetailQueryHandler(
                _logger.Object,
                _mapper,
                _mockEnvironmentRepository.Object,
                _mockDataCentreRepository.Object,
                _mockVlanRepository.Object);

            var getEnvironmentDetailQuery = new GetEnvironmentDetailQuery() { Id = Guid.NewGuid() };

            var result = await Should.ThrowAsync<NotFoundException>(() => handler.Handle(getEnvironmentDetailQuery, CancellationToken.None));

            result.ShouldBeOfType<NotFoundException>();
        }
    }
}