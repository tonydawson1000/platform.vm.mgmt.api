using MediatR;
using Microsoft.AspNetCore.Mvc;
using Platform.Vm.Mgmt.Application.Features.VmOrders.Commands.CreateVmOrder;
using Platform.Vm.Mgmt.Application.Features.VmOrders.Queries.GetVmOrderDetail;
using Platform.Vm.Mgmt.Application.Features.VmOrders.Queries.GetVmOrdersList;

namespace Platform.Vm.Mgmt.Api.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class VmOrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VmOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllVmOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetVmOrdersListQueryResponse>> GetAllVmOrders()
        {
            var response = await _mediator.Send(new GetVmOrdersListQuery());

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetVmOrderById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetVmOrderDetailQueryResponse>> GetVmOrderById(Guid id)
        {
            var getVmOrderDetailQuery = new GetVmOrderDetailQuery()
            {
                Id = id
            };

            var response = await _mediator.Send(getVmOrderDetailQuery);

            return Ok(response);
        }

        [HttpPost(Name = "AddVmOrder")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateVmOrderCommandResponse>> Create([FromBody] CreateVmOrderCommand createVmOrderCommand)
        {
            var response = await _mediator.Send(createVmOrderCommand);

            return CreatedAtRoute("GetVmOrderById", new { id = response.VmOrderId }, response);
        }
    }
}