using Microsoft.EntityFrameworkCore;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Persistence.EfCore.Repositories
{
    public class VmSizeRepository : BaseRepository<Domain.Entities.VmSize>, IVmSizeRepository
    {
        public VmSizeRepository(PlatformVmMgmtDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Domain.Entities.VmSize>> GetVmSizesAsync(bool includeDisabled)
        {
            var vmSizes = includeDisabled
                ? await _dbContext.VmSizes.ToListAsync()
                : await _dbContext.VmSizes.Where(x => x.IsEnabled).ToListAsync();

            return vmSizes;
        }
    }
}