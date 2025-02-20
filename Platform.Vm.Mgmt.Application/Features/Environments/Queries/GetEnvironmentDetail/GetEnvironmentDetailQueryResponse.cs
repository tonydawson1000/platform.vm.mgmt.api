using Platform.Vm.Mgmt.Application.Responses;

namespace Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentDetail
{
    public class GetEnvironmentDetailQueryResponse : BaseResponse
    {
        public GetEnvironmentDetailQueryResponse() : base() { }

        public EnvironmentDetailModel EnvironmentDetailModel { get; set; }
    }
}