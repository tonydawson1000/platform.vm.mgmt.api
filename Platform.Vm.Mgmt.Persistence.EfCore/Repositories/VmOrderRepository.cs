using Microsoft.EntityFrameworkCore;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;
using Platform.Vm.Mgmt.Domain.Entities;

namespace Platform.Vm.Mgmt.Persistence.EfCore.Repositories
{
    public class VmOrderRepository : BaseRepository<Domain.Entities.VmOrder>, IVmOrderRepository
    {
        public VmOrderRepository(PlatformVmMgmtDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<VmOrder> GetVmOrderByIdAsync(Guid id, bool includeVmOrderDetails)
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

        public async Task<IEnumerable<VmOrder>> GetVmOrdersAsync(bool includeVmOrderDetails)
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
    }
}