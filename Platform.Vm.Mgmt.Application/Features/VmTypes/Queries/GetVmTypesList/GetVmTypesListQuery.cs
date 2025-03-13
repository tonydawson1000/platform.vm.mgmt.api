using MediatR;

namespace Platform.Vm.Mgmt.Application.Features.VmTypes.Queries.GetVmTypesList
{
    public class GetVmTypesListQuery : IRequest<GetVmTypesListQueryResponse>
    {
        public bool IncludeDisabled { get; set; } = false;
    }
}