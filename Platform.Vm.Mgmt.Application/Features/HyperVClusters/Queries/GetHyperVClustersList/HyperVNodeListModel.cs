namespace Platform.Vm.Mgmt.Application.Features.HyperVClusters.Queries.GetHyperVClustersList
{
    public class HyperVNodeListModel
    {
        public Guid Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public string HostName { get; set; } = string.Empty;

        public Guid HyperVClusterId { get; set; }

        public Guid DataCentreId { get; set; }
    }
}