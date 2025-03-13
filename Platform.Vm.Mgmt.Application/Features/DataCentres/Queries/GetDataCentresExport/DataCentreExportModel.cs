namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresExport
{
    public class DataCentreExportModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsEnabled { get; set; } = true;
        
        public string? Location { get; set; }
    }
}