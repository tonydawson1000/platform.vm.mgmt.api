using Microsoft.EntityFrameworkCore;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Persistence.EfCore.Repositories
{
    public class VmTypeRepository : BaseRepository<Domain.Entities.VmType>, IVmTypeRepository
    {
        public VmTypeRepository(PlatformVmMgmtDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Domain.Entities.VmType>> GetVmTypesAsync(bool includeDisabled)
        {
            var vmTypes = includeDisabled
                ? await _dbContext.VmTypes.ToListAsync()
                : await _dbContext.VmTypes.Where(x => x.IsEnabled).ToListAsync();

            return vmTypes;
        }
    }
}