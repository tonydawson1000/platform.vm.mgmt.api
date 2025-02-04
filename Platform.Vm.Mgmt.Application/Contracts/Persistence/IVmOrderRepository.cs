using Platform.Vm.Mgmt.Domain.Entities;

namespace Platform.Vm.Mgmt.Application.Contracts.Persistence
{
    public interface IVmOrderRepository : IAsyncRepository<VmOrder>
    {
    }
}