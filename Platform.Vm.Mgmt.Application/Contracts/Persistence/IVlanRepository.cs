using Platform.Vm.Mgmt.Domain.Entities;

namespace Platform.Vm.Mgmt.Application.Contracts.Persistence
{
    public interface IVlanRepository : IAsyncRepository<Vlan>
    {
        Task<bool> IsVlanNameUnique(string name);
    }
}