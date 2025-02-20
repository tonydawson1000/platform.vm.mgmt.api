using Platform.Vm.Mgmt.Application.Responses;

namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentreDetail
{
    public class GetDataCentreDetailQueryResponse : BaseResponse
    {
        public GetDataCentreDetailQueryResponse() : base() { }

        public DataCentreDetailModel DataCentreDetailModel { get; set; }
    }
}