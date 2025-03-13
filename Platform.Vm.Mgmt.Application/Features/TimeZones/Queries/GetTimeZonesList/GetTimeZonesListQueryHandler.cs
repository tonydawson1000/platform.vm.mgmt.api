using AutoMapper;
using MediatR;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Application.Features.TimeZones.Queries.GetTimeZonesList
{
    public class GetTimeZonesListQueryHandler
        : IRequestHandler<GetTimeZonesListQuery, GetTimeZonesListQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.TimeZone> _timeZoneRepository;

        public GetTimeZonesListQueryHandler(
            IMapper mapper,
            IAsyncRepository<Domain.Entities.TimeZone> timeZoneRepository)
        {
            _mapper = mapper;
            _timeZoneRepository = timeZoneRepository;
        }

        public async Task<GetTimeZonesListQueryResponse> Handle(GetTimeZonesListQuery request, CancellationToken cancellationToken)
        {
            var getTimeZoneListQueryResponse = new GetTimeZonesListQueryResponse();

            var allTimeZones = (await _timeZoneRepository.ListAllAsync()).OrderBy(x => x.Sequence);

            var timeZoneListModels = _mapper.Map<List<TimeZoneListModel>>(allTimeZones);

            getTimeZoneListQueryResponse.TimeZoneListModels = timeZoneListModels;

            return getTimeZoneListQueryResponse;
        }
    }
}