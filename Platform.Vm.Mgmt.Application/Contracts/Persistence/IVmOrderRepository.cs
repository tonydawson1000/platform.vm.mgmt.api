namespace Platform.Vm.Mgmt.Application.Contracts.Persistence
{
    public interface IVmOrderRepository : IAsyncRepository<Domain.Entities.VmOrder>
    {
        Task<IEnumerable<Domain.Entities.VmOrder>> GetVmOrdersAsync(bool includeVmOrderDetails);

        Task<Domain.Entities.VmOrder> GetVmOrderByIdAsync(Guid id, bool includeVmOrderDetails);
    }
}