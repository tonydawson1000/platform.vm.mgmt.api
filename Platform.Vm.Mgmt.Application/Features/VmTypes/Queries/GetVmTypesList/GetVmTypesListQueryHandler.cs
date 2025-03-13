using AutoMapper;
using MediatR;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Application.Features.VmTypes.Queries.GetVmTypesList
{
    public class GetVmTypesListQueryHandler
        : IRequestHandler<GetVmTypesListQuery, GetVmTypesListQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVmTypeRepository _vmTypeRepository;

        public GetVmTypesListQueryHandler(
            IMapper mapper,
            IVmTypeRepository vmTypeRepository)
        {
            _mapper = mapper;
            _vmTypeRepository = vmTypeRepository;
        }

        public async Task<GetVmTypesListQueryResponse>
            Handle(GetVmTypesListQuery request, CancellationToken cancellationToken)
        {
            var getVmTypesListQueryResponse = new GetVmTypesListQueryResponse();

            var allVmTypes = (await _vmTypeRepository.GetVmTypesAsync(request.IncludeDisabled)).OrderBy(x => x.Sequence);

            var vmTypeListModels = _mapper.Map<List<VmTypeListModel>>(allVmTypes);

            getVmTypesListQueryResponse.VmTypeListModels = vmTypeListModels;

            return getVmTypesListQueryResponse;
        }
    }
}