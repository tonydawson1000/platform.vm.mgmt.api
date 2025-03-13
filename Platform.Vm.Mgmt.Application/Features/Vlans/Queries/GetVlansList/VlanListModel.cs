namespace Platform.Vm.Mgmt.Application.Features.Vlans.Queries.GetVlansList
{
    public class VlanListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsEnabled { get; set; } = true;
    }
}