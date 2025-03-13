namespace Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentsList
{
    public class EnvironmentListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsEnabled { get; set; } = true;

        public int? Tier { get; set; }

        public int? Sequence { get; set; }
    }
}