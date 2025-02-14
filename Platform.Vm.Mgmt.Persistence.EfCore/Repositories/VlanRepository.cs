using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Persistence.EfCore.Repositories
{
    public class VlanRepository : BaseRepository<Domain.Entities.Vlan>, IVlanRepository
    {
        public VlanRepository(PlatformVmMgmtDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsVlanNameUnique(string name)
        {
            var matches = _dbContext.Vlans.Any(v => v.Name.Equals(name));

            return Task.FromResult(matches);
        }
    }
}