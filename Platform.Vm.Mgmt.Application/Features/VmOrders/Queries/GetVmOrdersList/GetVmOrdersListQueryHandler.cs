using AutoMapper;
using MediatR;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Application.Features.VmOrders.Queries.GetVmOrdersList
{
    public class GetVmOrdersListQueryHandler
        : IRequestHandler<GetVmOrdersListQuery, GetVmOrdersListQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVmOrderRepository _vmOrderRepository;

        public GetVmOrdersListQueryHandler(
            IMapper mapper,
            IVmOrderRepository vmOrderRepository)
        {
            _mapper = mapper;
            _vmOrderRepository = vmOrderRepository;
        }

        public async Task<GetVmOrdersListQueryResponse>
            Handle(GetVmOrdersListQuery request, CancellationToken cancellationToken)
        {
            var getVmOrdersListQueryResponse = new GetVmOrdersListQueryResponse();

            var allVmOrders = await _vmOrderRepository.GetVmOrdersAsync(true);

            var vmOrdersListModels = _mapper.Map<List<VmOrderListModel>>(allVmOrders);

            getVmOrdersListQueryResponse.VmOrderListModels = vmOrdersListModels;

            return getVmOrdersListQueryResponse;
        }
    }
}