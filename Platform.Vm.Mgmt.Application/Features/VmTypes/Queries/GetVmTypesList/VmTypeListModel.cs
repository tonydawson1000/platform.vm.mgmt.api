namespace Platform.Vm.Mgmt.Application.Features.VmTypes.Queries.GetVmTypesList
{
    public class VmTypeListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsEnabled { get; set; } = true;
        public int? Sequence { get; set; }

        public string? OsType { get; set; }
        public string? OsVersion { get; set; }
    }
}