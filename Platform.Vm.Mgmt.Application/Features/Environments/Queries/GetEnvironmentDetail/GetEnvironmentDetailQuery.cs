using MediatR;

namespace Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentDetail
{
    public class GetEnvironmentDetailQuery : IRequest<EnvironmentDetailModel>
    {
        public Guid Id { get; set; }
    }
}