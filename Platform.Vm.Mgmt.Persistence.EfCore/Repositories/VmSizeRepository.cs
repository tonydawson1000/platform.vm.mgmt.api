using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Persistence.EfCore.Repositories
{
    public class VmSizeRepository : BaseRepository<Domain.Entities.VmSize>, IVmSizeRepository
    {
        public VmSizeRepository(PlatformVmMgmtDbContext dbContext) : base(dbContext)
        {
        }
    }
}