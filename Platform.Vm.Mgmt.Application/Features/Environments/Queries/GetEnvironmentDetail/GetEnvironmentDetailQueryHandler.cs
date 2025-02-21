using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;
using Platform.Vm.Mgmt.Application.Exceptions;
using Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresList;
using Platform.Vm.Mgmt.Application.Features.Vlans.Queries.GetVlansList;

namespace Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentDetail
{
    public class GetEnvironmentDetailQueryHandler
        : IRequestHandler<GetEnvironmentDetailQuery, GetEnvironmentDetailQueryResponse>
    {
        private readonly ILogger<GetEnvironmentDetailQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.Environment> _environmentRepository;
        private readonly IAsyncRepository<Domain.Entities.DataCentre> _dataCentreRepository;
        private readonly IAsyncRepository<Domain.Entities.Vlan> _vlanRepository;

        public GetEnvironmentDetailQueryHandler(
            ILogger<GetEnvironmentDetailQueryHandler> logger,
            IMapper mapper,
            IAsyncRepository<Domain.Entities.Environment> environmentRepository,
            IAsyncRepository<Domain.Entities.DataCentre> dataCentreRepository,
            IAsyncRepository<Domain.Entities.Vlan> vlanRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _environmentRepository = environmentRepository;
            _dataCentreRepository = dataCentreRepository;
            _vlanRepository = vlanRepository;
        }

        public async Task<GetEnvironmentDetailQueryResponse>
            Handle(GetEnvironmentDetailQuery request, CancellationToken cancellationToken)
        {
            var getEnvironmentDetailQueryResponse = new GetEnvironmentDetailQueryResponse();

            var environment = await _environmentRepository.GetByIdAsync(request.Id);

            if (environment == null)
            {
                _logger.LogInformation($"*** GetEnvironmentDetailQueryHandler - Environment with Id {request.Id} was not found.");

                throw new NotFoundException(nameof(Domain.Entities.Environment), request.Id);
            }

            var environmentDetailModel = _mapper.Map<EnvironmentDetailModel>(environment);

            var dataCentre = await _dataCentreRepository.GetByIdAsync(environmentDetailModel.DataCentreId);
            var dataCentreListModel = _mapper.Map<DataCentreListModel>(dataCentre);

            environmentDetailModel.DataCentreListModel = dataCentreListModel;

            var vlans = (await _vlanRepository.ListAllAsync())
                .Where(x => x.EnvironmentId == environment.Id)
                .OrderBy(x => x.Name);

            var vlanListModels = _mapper.Map<List<VlanListModel>>(vlans);

            environmentDetailModel.VlanListModels = vlanListModels;

            getEnvironmentDetailQueryResponse.EnvironmentDetailModel = environmentDetailModel;

            return getEnvironmentDetailQueryResponse;
        }
    }
}