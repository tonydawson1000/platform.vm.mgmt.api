using MediatR;

namespace Platform.Vm.Mgmt.Application.Features.VmSizes.Queries
{
    public class GetVmSizesListQuery : IRequest<GetVmSizesListQueryResponse>
    {
        public bool IncludeDisabled { get; set; } = false;
    }
}