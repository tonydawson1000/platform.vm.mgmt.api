namespace Platform.Vm.Mgmt.Application.Features.Vlans.Commands.CreateVlan
{
    public class CreateVlanModel
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public bool? IsEnabled { get; set; } = true;

        public Guid EnvironmentId { get; set; }
    }
}