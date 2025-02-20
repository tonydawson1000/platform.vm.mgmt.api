using MediatR;

namespace Platform.Vm.Mgmt.Application.Features.Vlans.Queries.GetVlanDetail
{
    public class GetVlanDetailQuery : IRequest<GetVlanDetailQueryResponse>
    {
        public Guid Id { get; set; }
    }
}