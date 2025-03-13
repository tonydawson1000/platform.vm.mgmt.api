using AutoMapper;
using MediatR;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Application.Features.VmSizes.Queries
{
    public class GetVmSizesListQueryHandler
        : IRequestHandler<GetVmSizesListQuery, GetVmSizesListQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVmSizeRepository _vmSizeRepository;

        public GetVmSizesListQueryHandler(
            IMapper mapper,
            IVmSizeRepository vmSizeRepository)
        {
            _mapper = mapper;
            _vmSizeRepository = vmSizeRepository;
        }

        public async Task<GetVmSizesListQueryResponse>
            Handle(GetVmSizesListQuery request, CancellationToken cancellationToken)
        {
            var getVmSizesListQueryResponse = new GetVmSizesListQueryResponse();

            var allVmSizes = (await _vmSizeRepository.GetVmSizesAsync(request.IncludeDisabled)).OrderBy(x => x.Sequence);

            var vmSizeListModels = _mapper.Map<List<VmSizeListModel>>(allVmSizes);

            getVmSizesListQueryResponse.VmSizeListModels = vmSizeListModels;

            return getVmSizesListQueryResponse;
        }
    }
}