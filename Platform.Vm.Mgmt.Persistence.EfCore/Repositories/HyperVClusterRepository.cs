using Microsoft.EntityFrameworkCore;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Persistence.EfCore.Repositories
{
    public class HyperVClusterRepository : BaseRepository<Domain.Entities.HyperVCluster>, IHyperVClusterRepository
    {

        public HyperVClusterRepository(PlatformVmMgmtDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Domain.Entities.HyperVCluster?> GetHyperVClusterByIdAsync(Guid id, bool includeHyperVNodes)
        {
            var hyperVCluster =
                await _dbContext.HyperVClusters
                .Include(hv => hv.HyperVNodes)
                .FirstOrDefaultAsync(hv => hv.Id == id);

            if (!includeHyperVNodes)
            {
                hyperVCluster?.HyperVNodes?.Clear();
            }

            return hyperVCluster;
        }

        public async Task<IEnumerable<Domain.Entities.HyperVCluster>> GetHyperVClustersAsync(bool includeHyperVNodes)
        {
            var hyperVClusters =
                await _dbContext.HyperVClusters
                    .Include(hv => hv.HyperVNodes)
                    .ToListAsync();

            if (!includeHyperVNodes)
            {
                hyperVClusters.ForEach(hv => hv.HyperVNodes?.Clear());
            }

            return hyperVClusters;
        }
    }
}