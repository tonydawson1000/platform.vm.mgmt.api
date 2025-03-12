using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;
using Platform.Vm.Mgmt.Application.Exceptions;

namespace Platform.Vm.Mgmt.Application.Features.VmOrders.Queries.GetVmOrderDetail
{
    public class GetVmOrderDetailQueryHandler
        : IRequestHandler<GetVmOrderDetailQuery, GetVmOrderDetailQueryResponse>
    {
        private readonly ILogger<GetVmOrderDetailQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IVmOrderRepository _vmOrderRepository;

        public GetVmOrderDetailQueryHandler(
            ILogger<GetVmOrderDetailQueryHandler> logger,
            IMapper mapper,
            IVmOrderRepository vmOrderRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _vmOrderRepository = vmOrderRepository;
        }

        public async Task<GetVmOrderDetailQueryResponse>
            Handle(GetVmOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var getVmOrderDetailQueryResponse = new GetVmOrderDetailQueryResponse();

            var vmOrder = await _vmOrderRepository.GetVmOrderByIdAsync(request.Id, true);

            if (vmOrder == null)
            {
                _logger.LogInformation($"*** GetVmOrderDetailQueryHandler - VM Order with Id {request.Id} was not found.");

                throw new NotFoundException(nameof(Domain.Entities.VmOrder), request.Id);
            }

            var vmOrderDetailModel = _mapper.Map<VmOrderDetailModel>(vmOrder);

            getVmOrderDetailQueryResponse.VmOrderDetailModel = vmOrderDetailModel;

            return getVmOrderDetailQueryResponse;
        }
    }
}