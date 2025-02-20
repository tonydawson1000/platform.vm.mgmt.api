using MediatR;

namespace Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentDetail
{
    public class GetEnvironmentDetailQuery : IRequest<GetEnvironmentDetailQueryResponse>
    {
        public Guid Id { get; set; }
    }
}