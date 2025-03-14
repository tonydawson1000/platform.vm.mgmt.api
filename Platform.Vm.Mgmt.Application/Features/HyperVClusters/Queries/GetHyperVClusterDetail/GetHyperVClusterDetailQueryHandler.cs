using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;
using Platform.Vm.Mgmt.Application.Exceptions;

namespace Platform.Vm.Mgmt.Application.Features.HyperVClusters.Queries.GetHyperVClusterDetail
{
    public class GetHyperVClusterDetailQueryHandler
        : IRequestHandler<GetHyperVClusterDetailQuery, GetHyperVClusterDetailQueryResponse>
    {
        private readonly ILogger<GetHyperVClusterDetailQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IHyperVClusterRepository _hyperVClusterRepository;

        public GetHyperVClusterDetailQueryHandler(
            ILogger<GetHyperVClusterDetailQueryHandler> logger,
            IMapper mapper,
            IHyperVClusterRepository hyperVClusterRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _hyperVClusterRepository = hyperVClusterRepository;
        }

        public async Task<GetHyperVClusterDetailQueryResponse>
            Handle(GetHyperVClusterDetailQuery request, CancellationToken cancellationToken)
        {
            var getHyperVClusterDetailQueryResponse = new GetHyperVClusterDetailQueryResponse();

            var hyperVCluster = await _hyperVClusterRepository.GetHyperVClusterByIdAsync(request.Id, true);

            if (hyperVCluster == null)
            {
                _logger.LogInformation($"*** GetHyperVClusterDetailQueryHandler - HyperV Cluster with Id {request.Id} was not found.");

                throw new NotFoundException(nameof(Domain.Entities.HyperVCluster), request.Id);
            }

            var hyperVClusterDetailModel = _mapper.Map<HyperVClusterDetailModel>(hyperVCluster);

            getHyperVClusterDetailQueryResponse.HyperVClusterDetailModel = hyperVClusterDetailModel;

            return getHyperVClusterDetailQueryResponse;
        }
    }
}