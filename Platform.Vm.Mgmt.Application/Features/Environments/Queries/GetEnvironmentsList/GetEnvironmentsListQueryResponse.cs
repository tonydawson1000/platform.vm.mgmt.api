using Platform.Vm.Mgmt.Application.Responses;

namespace Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentsList
{
    public class GetEnvironmentsListQueryResponse : BaseResponse
    {
        public GetEnvironmentsListQueryResponse() : base() { }

        public List<EnvironmentListModel>? EnvironmentListModels { get; set; }
    }
}