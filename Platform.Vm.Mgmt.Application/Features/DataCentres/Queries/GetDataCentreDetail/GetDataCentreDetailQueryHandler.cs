using AutoMapper;
using MediatR;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;
using Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentsList;

namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentreDetail
{
    public class GetDataCentreDetailQueryHandler
        : IRequestHandler<GetDataCentreDetailQuery, GetDataCentreDetailQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.DataCentre> _dataCentreRepository;
        private readonly IAsyncRepository<Domain.Entities.Environment> _environmentRepository;

        public GetDataCentreDetailQueryHandler(
            IMapper mapper,
            IAsyncRepository<Domain.Entities.DataCentre> dataCentreRepository,
            IAsyncRepository<Domain.Entities.Environment> environmentRepository)
        {
            _mapper = mapper;
            _dataCentreRepository = dataCentreRepository;
            _environmentRepository = environmentRepository;
        }

        public async Task<GetDataCentreDetailQueryResponse>
            Handle(GetDataCentreDetailQuery request, CancellationToken cancellationToken)
        {
            var getDataCentreDetailQueryResponse = new GetDataCentreDetailQueryResponse();

            var dataCentre = await _dataCentreRepository.GetByIdAsync(request.Id);
            var dataCentreDetailModel = _mapper.Map<DataCentreDetailModel>(dataCentre);

            var environments = (await _environmentRepository.ListAllAsync())
                .Where(x => x.DataCentreId == dataCentre.Id)
                .OrderBy(x => x.Name);

            var environmentListModels = _mapper.Map<List<EnvironmentListModel>>(environments);

            dataCentreDetailModel.EnvironmentListModels = environmentListModels;

            getDataCentreDetailQueryResponse.DataCentreDetailModel = dataCentreDetailModel;

            return getDataCentreDetailQueryResponse;
        }
    }
}