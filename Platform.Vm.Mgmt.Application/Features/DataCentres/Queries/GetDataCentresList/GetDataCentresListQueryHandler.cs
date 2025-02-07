using AutoMapper;
using MediatR;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresList
{
    public class GetDataCentresListQueryHandler
        : IRequestHandler<GetDataCentresListQuery, List<DataCentreListModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.DataCentre> _dataCentreRepository;

        public GetDataCentresListQueryHandler(
            IMapper mapper,
            IAsyncRepository<Domain.Entities.DataCentre> dataCentreRepository)
        {
            _mapper = mapper;
            _dataCentreRepository = dataCentreRepository;
        }

        public async Task<List<DataCentreListModel>> 
            Handle(GetDataCentresListQuery request, CancellationToken cancellationToken)
        {
            var allDataCentres = (await _dataCentreRepository.ListAllAsync()).OrderBy(x => x.Name);

            var dataCentreListModels = _mapper.Map<List<DataCentreListModel>>(allDataCentres);

            return dataCentreListModels;
        }
    }
}