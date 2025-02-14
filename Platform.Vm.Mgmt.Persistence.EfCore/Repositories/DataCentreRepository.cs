using Microsoft.EntityFrameworkCore;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Persistence.EfCore.Repositories
{
    public class DataCentreRepository : BaseRepository<Domain.Entities.DataCentre>, IDataCentreRepository
    {
        public DataCentreRepository(PlatformVmMgmtDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Domain.Entities.DataCentre>> GetDataCentresWithEnvironments(bool includeDisabledEnvironments)
        {
            var allDataCentresWithEnvironments =
                await _dbContext.DataCentres.Include(dc => dc.Environments).ToListAsync();

            if(!includeDisabledEnvironments)
            {
                allDataCentresWithEnvironments.ForEach(dc => dc.Environments?.ToList().RemoveAll(e => e.IsEnabled == false));
            }

            return allDataCentresWithEnvironments;
        }

        public Task<bool> IsDataCentreNameUnique(string name)
        {
            var matches = _dbContext.DataCentres.Any(dc => dc.Name.Equals(name));

            return Task.FromResult(matches);
        }
    }
}