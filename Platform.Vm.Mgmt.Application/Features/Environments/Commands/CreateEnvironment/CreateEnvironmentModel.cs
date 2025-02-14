namespace Platform.Vm.Mgmt.Application.Features.Environments.Commands.CreateEnvironment
{
    public class CreateEnvironmentModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsEnabled { get; set; } = true;

        public int? Tier { get; set; }

        public int Sequence { get; set; }

        public Guid DataCentreId { get; set; }
    }
}