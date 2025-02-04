using Platform.Vm.Mgmt.Domain.Entities;

namespace Platform.Vm.Mgmt.Application.Contracts.Persistence
{
    public interface IDataCentreRepository : IAsyncRepository<DataCentre>
    {
        Task<bool> IsDataCentreNameUnique(string name);

        Task<List<DataCentre>> GetDataCentresWithEnvironments(bool includeDisabledEnvironments);
    }
}