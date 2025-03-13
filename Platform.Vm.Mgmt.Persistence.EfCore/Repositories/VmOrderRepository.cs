using Microsoft.EntityFrameworkCore;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Persistence.EfCore.Repositories
{
    public class VmOrderRepository : BaseRepository<Domain.Entities.VmOrder>, IVmOrderRepository
    {
        public VmOrderRepository(PlatformVmMgmtDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Domain.Entities.VmOrder>> GetVmOrdersAsync(bool includeVmOrderDetails)
        {
            var vmOrders =
                await _dbContext.VmOrders
                    .Include(vo => vo.VmOrderDetails)
                    .ToListAsync();

            if (!includeVmOrderDetails)
            {
                vmOrders.ForEach(v => v.VmOrderDetails?.Clear());
            }

            return vmOrders;
        }

        public async Task<Domain.Entities.VmOrder?> GetVmOrderByIdAsync(Guid id, bool includeVmOrderDetails)
        {
            var vmOrder =
                await _dbContext.VmOrders
                .Include(vo => vo.VmOrderDetails)
                .FirstOrDefaultAsync(vo => vo.Id == id);

            if (!includeVmOrderDetails)
            {
                vmOrder?.VmOrderDetails?.Clear();
            }

            return vmOrder;
        }
    }
}