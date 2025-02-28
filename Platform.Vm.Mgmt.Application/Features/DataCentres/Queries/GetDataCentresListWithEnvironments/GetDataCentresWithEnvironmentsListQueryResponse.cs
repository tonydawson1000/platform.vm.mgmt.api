using Platform.Vm.Mgmt.Application.Responses;

namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresListWithEnvironments
{
    public class GetDataCentresWithEnvironmentsListQueryResponse : BaseResponse
    {
        public GetDataCentresWithEnvironmentsListQueryResponse() : base() { }

        public List<DataCentreWithEnvironmentsListModel>? DataCentreWithEnvironmentsListModels { get; set; }
    }
}