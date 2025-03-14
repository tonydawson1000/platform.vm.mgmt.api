namespace Platform.Vm.Mgmt.Application.Features.HyperVClusters.Queries.GetHyperVClustersList
{
    public class HyperVClusterListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<HyperVNodeListModel>? HyperVNodeListModels { get; set; }
    }
}