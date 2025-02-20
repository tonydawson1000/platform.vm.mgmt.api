namespace Platform.Vm.Mgmt.Application.Responses
{
    public class BaseExportFileModel
    {
        public string ExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}