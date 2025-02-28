namespace Platform.Vm.Mgmt.Application.Contracts.Persistence
{
    public interface IDataCentreRepository : IAsyncRepository<Domain.Entities.DataCentre>
    {
        Task<bool> IsDataCentreNameUnique(string name);

        Task<IEnumerable<Domain.Entities.DataCentre>> GetDataCentresWithEnvironmentsAsync(bool includeDisabledEnvironments);
    }
}