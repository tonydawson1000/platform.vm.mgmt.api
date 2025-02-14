using Platform.Vm.Mgmt.Application.Contracts.Persistence;
using Platform.Vm.Mgmt.Domain.Entities;

namespace Platform.Vm.Mgmt.Persistence.EfCore.Repositories
{
    public class EnvironmentRepository : BaseRepository<Domain.Entities.Environment>, IEnvironmentRepository
    {
        public EnvironmentRepository(PlatformVmMgmtDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Vlan>> GetEnvironmentsWithVlans(bool includeDisabledVlans)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsEnvironmentNameUnique(string name)
        {
            var matches = _dbContext.Environments.Any(e => e.Name.Equals(name));

            return Task.FromResult(matches);
        }

        public Task<bool> IsEnvironmentSequenceUnique(int sequence)
        {
            var matches = _dbContext.Environments.Any(e => e.Sequence.Equals(sequence));

            return Task.FromResult(matches);
        }
    }
}