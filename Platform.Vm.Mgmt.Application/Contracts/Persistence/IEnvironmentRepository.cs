namespace Platform.Vm.Mgmt.Application.Contracts.Persistence
{
    public interface IEnvironmentRepository : IAsyncRepository<Domain.Entities.Environment>
    {
        Task<bool> IsEnvironmentNameUnique(string name);
        Task<bool> IsEnvironmentSequenceUnique(int sequence);

        Task<List<Domain.Entities.Vlan>> GetEnvironmentsWithVlans(bool includeDisabledVlans);
    }
}