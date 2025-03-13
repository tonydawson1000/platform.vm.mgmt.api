namespace Platform.Vm.Mgmt.Application.Contracts.Persistence
{
    public interface IVmSizeRepository : IAsyncRepository<Domain.Entities.VmSize>
    {
        Task<IEnumerable<Domain.Entities.VmSize>> GetVmSizesAsync(bool includeDisabled);
    }
}