using MediatR;

namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresListWithEnvironments
{
    public class GetDataCentresWithEnvironmentsListQuery : IRequest<GetDataCentresWithEnvironmentsListQueryResponse>
    {
        public bool IncludeDisabledEnvironments { get; set; }
    }
}