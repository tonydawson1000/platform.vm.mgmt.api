using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;
using Platform.Vm.Mgmt.Application.Exceptions;
using Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentsList;

namespace Platform.Vm.Mgmt.Application.Features.Vlans.Queries.GetVlanDetail
{
    public class GetVlanDetailQueryHandler
        : IRequestHandler<GetVlanDetailQuery, GetVlanDetailQueryResponse>
    {
        private readonly ILogger<GetVlanDetailQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.Vlan> _vlanRepository;
        private readonly IAsyncRepository<Domain.Entities.Environment> _environmentRepository;

        public GetVlanDetailQueryHandler(
            ILogger<GetVlanDetailQueryHandler> logger,
            IMapper mapper,
            IAsyncRepository<Domain.Entities.Vlan> vlanRepository,
            IAsyncRepository<Domain.Entities.Environment> environmentRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _vlanRepository = vlanRepository;
            _environmentRepository = environmentRepository;
        }

        public async Task<GetVlanDetailQueryResponse>
            Handle(GetVlanDetailQuery request, CancellationToken cancellationToken)
        {
            var getVlanDetailQueryResponse = new GetVlanDetailQueryResponse();

            var vlan = await _vlanRepository.GetByIdAsync(request.Id);

            if (vlan == null)
            {
                _logger.LogInformation($"*** GetVlanDetailQueryHandler - VLAN with Id {request.Id} was not found.");

                throw new NotFoundException(nameof(Domain.Entities.Vlan), request.Id);
            }

            var vlanDetailModel = _mapper.Map<VlanDetailModel>(vlan);

            var environment = await _environmentRepository.GetByIdAsync(vlan.EnvironmentId);
            var environmentListModel = _mapper.Map<EnvironmentListModel>(environment);

            vlanDetailModel.EnvironmentListModel = environmentListModel;

            getVlanDetailQueryResponse.VlanDetailModel = vlanDetailModel;

            return getVlanDetailQueryResponse;
        }
    }
}