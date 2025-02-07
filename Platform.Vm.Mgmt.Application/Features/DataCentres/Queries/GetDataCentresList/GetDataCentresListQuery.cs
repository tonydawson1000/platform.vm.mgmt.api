using MediatR;

namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresList
{
    public class GetDataCentresListQuery : IRequest<List<DataCentreListModel>>
    {
    }
}