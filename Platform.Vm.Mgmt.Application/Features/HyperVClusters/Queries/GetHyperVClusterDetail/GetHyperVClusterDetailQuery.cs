using MediatR;

namespace Platform.Vm.Mgmt.Application.Features.HyperVClusters.Queries.GetHyperVClusterDetail
{
    public class GetHyperVClusterDetailQuery : IRequest<GetHyperVClusterDetailQueryResponse>
    {
        public Guid Id { get; set; }
    }
}