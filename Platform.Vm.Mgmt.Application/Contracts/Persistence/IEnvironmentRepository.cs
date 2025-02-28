namespace Platform.Vm.Mgmt.Application.Contracts.Persistence
{
    public interface IEnvironmentRepository : IAsyncRepository<Domain.Entities.Environment>
    {
        Task<bool> IsEnvironmentNameUnique(string name);
        Task<bool> IsEnvironmentSequenceUnique(int sequence);

        Task<IEnumerable<Domain.Entities.Vlan>> GetEnvironmentsWithVlansAsync(bool includeDisabledVlans);
    }
}