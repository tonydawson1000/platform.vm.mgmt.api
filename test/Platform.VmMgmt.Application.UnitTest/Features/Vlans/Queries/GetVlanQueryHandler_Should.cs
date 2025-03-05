using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;
using Platform.Vm.Mgmt.Application.Exceptions;
using Platform.Vm.Mgmt.Application.Features.Vlans.Queries.GetVlanDetail;
using Platform.Vm.Mgmt.Application.Features.Vlans.Queries.GetVlansList;
using Platform.Vm.Mgmt.Application.Profiles;
using Platform.VmMgmt.Application.UnitTest.Mocks;
using Shouldly;

namespace Platform.VmMgmt.Application.UnitTest.Features.Vlans.Queries
{
    public class GetVlanQueryHandler_Should
    {
        private readonly Mock<ILogger<GetVlanDetailQueryHandler>> _logger;
        private readonly Mock<IAsyncRepository<Vm.Mgmt.Domain.Entities.Vlan>> _mockVlanRepository;
        private readonly Mock<IAsyncRepository<Vm.Mgmt.Domain.Entities.Environment>> _mockEnvironmentRepository;
        private readonly IMapper _mapper;

        public GetVlanQueryHandler_Should()
        {
            _logger = new Mock<ILogger<GetVlanDetailQueryHandler>>();

            _mockVlanRepository = RepositoryMocks.GetVlanRepository();
            _mockEnvironmentRepository = RepositoryMocks.GetEnvironmentRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Return_VlansListQueryResponse_WhenListQueryRequested()
        {
            var handler = new GetVlansListQueryHandler(
                _mapper,
                _mockVlanRepository.Object);

            var result = await handler.Handle(new GetVlansListQuery(), CancellationToken.None);

            result.ShouldBeOfType<GetVlansListQueryResponse>();
        }

        [Fact]
        public async Task Throw_NotFoundException_WhenIdDoesntExist()
        {
            var handler = new GetVlanDetailQueryHandler(
                _logger.Object,
                _mapper,
                _mockVlanRepository.Object,
                _mockEnvironmentRepository.Object);

            var getVlanDetailQuery = new GetVlanDetailQuery() { Id = Guid.NewGuid() };

            var result = await Should.ThrowAsync<NotFoundException>(() => handler.Handle(getVlanDetailQuery, CancellationToken.None));

            result.ShouldBeOfType<NotFoundException>();
        }
    }
}