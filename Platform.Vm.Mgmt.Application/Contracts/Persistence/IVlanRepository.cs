namespace Platform.Vm.Mgmt.Application.Contracts.Persistence
{
    public interface IVlanRepository : IAsyncRepository<Domain.Entities.Vlan>
    {
        Task<bool> IsVlanNameUnique(string name);
    }
}