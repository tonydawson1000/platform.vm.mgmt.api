namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresExport
{
    public class DataCentreExportModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public string? Location { get; set; }
        public bool? IsEnabled { get; set; }
    }
}