namespace Platform.Vm.Mgmt.Application.Contracts.Persistence
{
    public interface IDataCentreRepository : IAsyncRepository<Domain.Entities.DataCentre>
    {
        Task<bool> IsDataCentreNameUnique(string name);

        Task<List<Domain.Entities.DataCentre>> GetDataCentresWithEnvironments(bool includeDisabledEnvironments);
    }
}