namespace Platform.Vm.Mgmt.Application.Contracts.Persistence
{
    public interface IVmTypeRepository : IAsyncRepository<Domain.Entities.VmType>
    {
        Task<IEnumerable<Domain.Entities.VmType>> GetVmTypesAsync(bool includeDisabled);
    }
}