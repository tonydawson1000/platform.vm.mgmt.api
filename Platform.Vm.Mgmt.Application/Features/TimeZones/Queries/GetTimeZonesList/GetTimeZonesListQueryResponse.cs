using Platform.Vm.Mgmt.Application.Responses;

namespace Platform.Vm.Mgmt.Application.Features.TimeZones.Queries.GetTimeZonesList
{
    public class GetTimeZonesListQueryResponse : BaseResponse
    {
        public GetTimeZonesListQueryResponse() : base() { }

        public List<TimeZoneListModel>? TimeZoneListModels { get; set; }
    }
}