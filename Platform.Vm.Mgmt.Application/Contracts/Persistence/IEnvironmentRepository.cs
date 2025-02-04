namespace Platform.Vm.Mgmt.Application.Contracts.Persistence
{
    public interface IEnvironmentRepository : IAsyncRepository<Domain.Entities.Environment>
    {
        Task<bool> IsEnvironmentNameUnique(string name);
    }
}