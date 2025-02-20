using MediatR;

namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresExport
{
    public class GetDataCentresExportQuery : IRequest<DataCentreExportFileModel>
    {
    }
}