using Platform.Vm.Mgmt.Application.Responses;

namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresList
{
    public class GetDataCentresListQueryResponse : BaseResponse
    {
        public GetDataCentresListQueryResponse() : base() { }

        public List<DataCentreListModel>? DataCentreListModels { get; set; }
    }
}