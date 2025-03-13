using Platform.Vm.Mgmt.Application.Responses;

namespace Platform.Vm.Mgmt.Application.Features.VmTypes.Queries.GetVmTypesList
{
    public class GetVmTypesListQueryResponse : BaseResponse
    {
        public GetVmTypesListQueryResponse() : base() { }

        public List<VmTypeListModel>? VmTypeListModels { get; set; }
    }
}