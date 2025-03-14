namespace Platform.Vm.Mgmt.Application.Contracts.Persistence
{
    public interface IHyperVClusterRepository : IAsyncRepository<Domain.Entities.HyperVCluster>
    {
        Task<IEnumerable<Domain.Entities.HyperVCluster>> GetHyperVClustersAsync(bool includeHyperVNodes);
        Task<Domain.Entities.HyperVCluster?> GetHyperVClusterByIdAsync(Guid id, bool includeHyperVNodes);
    }
}