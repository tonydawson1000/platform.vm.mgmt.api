using AutoMapper;
using MediatR;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresListWithEnvironments
{
    public class GetDataCentresWithEnvironmentsListQueryHandler
        : IRequestHandler<GetDataCentresWithEnvironmentsListQuery, GetDataCentresWithEnvironmentsListQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDataCentreRepository _dataCentreRepository;

        public GetDataCentresWithEnvironmentsListQueryHandler(
             IMapper mapper,
             IDataCentreRepository dataCentreRepository)
        {
            _mapper = mapper;
            _dataCentreRepository = dataCentreRepository;
        }

        public async Task<GetDataCentresWithEnvironmentsListQueryResponse>
            Handle(GetDataCentresWithEnvironmentsListQuery request, CancellationToken cancellationToken)
        {
            var getDataCentresWithEnvironmentsListQueryResponse = new GetDataCentresWithEnvironmentsListQueryResponse();

            var allDataCentresWithEnvironments = await _dataCentreRepository.GetDataCentresWithEnvironments(request.IncludeDisabledEnvironments);

            var dataCentreWithEnvironmentsListModels = _mapper.Map<List<DataCentreWithEnvironmentsListModel>>(allDataCentresWithEnvironments);

            getDataCentresWithEnvironmentsListQueryResponse.DataCentreWithEnvironmentsListModels = dataCentreWithEnvironmentsListModels;

            return getDataCentresWithEnvironmentsListQueryResponse;
        }
    }
}