using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Persistence.EfCore.Repositories
{
    public class TimeZoneRepository : BaseRepository<Domain.Entities.TimeZone>, ITimeZoneRepository
    {
        public TimeZoneRepository(PlatformVmMgmtDbContext dbContext) : base(dbContext)
        {
        }
    }
}