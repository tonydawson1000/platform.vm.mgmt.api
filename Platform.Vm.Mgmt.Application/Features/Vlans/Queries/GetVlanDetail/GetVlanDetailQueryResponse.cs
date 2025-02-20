using Platform.Vm.Mgmt.Application.Responses;

namespace Platform.Vm.Mgmt.Application.Features.Vlans.Queries.GetVlanDetail
{
    public class GetVlanDetailQueryResponse : BaseResponse
    {
        public GetVlanDetailQueryResponse() : base() { }

        public VlanDetailModel VlanDetailModel { get; set; }
    }
}