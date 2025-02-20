using CsvHelper;
using Platform.Vm.Mgmt.Application.Contracts.Infrastructure.Export;
using Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresExport;
using System.Globalization;

namespace Platform.Vm.Mgmt.Infrastructure.Export
{
    public class CsvFileExporter : ICsvFileExporter
    {
        public byte[] ExportDataCentresToCsv(List<DataCentreExportModel> dataCentreExportModels)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(dataCentreExportModels);
            }

            return memoryStream.ToArray();
        }
    }
}