using Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresExport;

namespace Platform.Vm.Mgmt.Application.Contracts.Infrastructure.Export
{
    public interface ICsvFileExporter
    {
        byte[] ExportDataCentresToCsv(List<DataCentreExportModel> dataCentreExportModels);
    }
}