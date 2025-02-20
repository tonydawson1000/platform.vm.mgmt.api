using Platform.Vm.Mgmt.Application.Responses;

namespace Platform.Vm.Mgmt.Application.Features.Vlans.Queries.GetVlansList
{
    public class GetVlansListQueryResponse : BaseResponse
    {
        public GetVlansListQueryResponse() : base() { }

        public List<VlanListModel> VlanListModels { get; set; }
    }
}