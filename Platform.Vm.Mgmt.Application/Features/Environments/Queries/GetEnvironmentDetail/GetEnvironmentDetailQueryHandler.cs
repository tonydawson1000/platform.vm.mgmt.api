using AutoMapper;
using MediatR;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;
using Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresList;
using Platform.Vm.Mgmt.Application.Features.Vlans.Queries.GetVlansList;

namespace Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentDetail
{
    public class GetEnvironmentDetailQueryHandler
        : IRequestHandler<GetEnvironmentDetailQuery, EnvironmentDetailModel>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.Environment> _environmentRepository;
        private readonly IAsyncRepository<Domain.Entities.DataCentre> _dataCentreRepository;
        private readonly IAsyncRepository<Domain.Entities.Vlan> _vlanRepository;

        public GetEnvironmentDetailQueryHandler(
            IMapper mapper,
            IAsyncRepository<Domain.Entities.Environment> environmentRepository,
            IAsyncRepository<Domain.Entities.DataCentre> dataCentreRepository,
            IAsyncRepository<Domain.Entities.Vlan> vlanRepository)
        {
            _mapper = mapper;
            _environmentRepository = environmentRepository;
            _dataCentreRepository = dataCentreRepository;
            _vlanRepository = vlanRepository;
        }

        public async Task<EnvironmentDetailModel>
            Handle(GetEnvironmentDetailQuery request, CancellationToken cancellationToken)
        {
            var environment = await _environmentRepository.GetByIdAsync(request.Id);
            var environmentDetailModel = _mapper.Map<EnvironmentDetailModel>(environment);

            var dataCentre = await _dataCentreRepository.GetByIdAsync(environmentDetailModel.DataCentreId);
            var dataCentreListModel = _mapper.Map<DataCentreListModel>(dataCentre);

            environmentDetailModel.DataCentreListModel = dataCentreListModel;

            var vlans = (await _vlanRepository.ListAllAsync())
                .Where(x => x.EnvironmentId == environment.Id)
                .OrderBy(x => x.Name);

            var vlanListModels = _mapper.Map<List<VlanListModel>>(vlans);

            environmentDetailModel.VlanListModels = vlanListModels;

            return environmentDetailModel;
        }
    }
}