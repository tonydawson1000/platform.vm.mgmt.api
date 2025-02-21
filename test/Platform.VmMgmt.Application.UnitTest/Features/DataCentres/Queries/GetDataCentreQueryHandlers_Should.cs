using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;
using Platform.Vm.Mgmt.Application.Exceptions;
using Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentreDetail;
using Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresList;
using Platform.Vm.Mgmt.Application.Profiles;
using Platform.VmMgmt.Application.UnitTest.Mocks;
using Shouldly;

namespace Platform.VmMgmt.Application.UnitTest.Features.DataCentres.Queries
{
    public class GetDataCentreQueryHandlers_Should
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Vm.Mgmt.Domain.Entities.DataCentre>> _mockDataCentreRepository;
        private readonly Mock<IAsyncRepository<Vm.Mgmt.Domain.Entities.Environment>> _mockEnvironmentRepository;
        private readonly Mock<ILogger<GetDataCentreDetailQueryHandler>> _logger;

        public GetDataCentreQueryHandlers_Should()
        {
            _logger = new Mock<ILogger<GetDataCentreDetailQueryHandler>>();

            _mockDataCentreRepository = RepositoryMocks.GetDataCentreRepository();
            _mockEnvironmentRepository = RepositoryMocks.GetEnvironmentRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Return_GetDataCentresListQueryResponse_WhenListQueryRequested()
        {
            var handler = new GetDataCentresListQueryHandler(
                _mapper,
                _mockDataCentreRepository.Object);

            var result = await handler.Handle(new GetDataCentresListQuery(), CancellationToken.None);

            result.ShouldBeOfType<GetDataCentresListQueryResponse>();
        }

        [Fact]
        public async Task Throw_NotFoundException_WhenIdDoesntExist()
        {
            var handler = new GetDataCentreDetailQueryHandler(
                _logger.Object,
                _mapper,
                _mockDataCentreRepository.Object,
                _mockEnvironmentRepository.Object);

            var getDataCentreDetailQuery = new GetDataCentreDetailQuery() { Id = Guid.NewGuid() };

            var result = await Should.ThrowAsync<NotFoundException>(() => handler.Handle(getDataCentreDetailQuery, CancellationToken.None));

            result.ShouldBeOfType<NotFoundException>();
        }
    }
}