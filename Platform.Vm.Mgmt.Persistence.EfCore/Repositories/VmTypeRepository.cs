using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Persistence.EfCore.Repositories
{
    public class VmTypeRepository : BaseRepository<Domain.Entities.VmType>, IVmTypeRepository
    {
        public VmTypeRepository(PlatformVmMgmtDbContext dbContext) : base(dbContext)
        {
        }
    }
}