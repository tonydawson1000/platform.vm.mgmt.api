using MediatR;
using Microsoft.AspNetCore.Mvc;
using Platform.Vm.Mgmt.Application.Features.Vlans.Queries.GetVlanDetail;
using Platform.Vm.Mgmt.Application.Features.Vlans.Queries.GetVlansList;

namespace Platform.Vm.Mgmt.Api.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class VlanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VlanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllVlans")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetVlansListQueryResponse>> GetAllVlans()
        {
            var response = await _mediator.Send(new GetVlansListQuery());

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetVlanById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetVlanDetailQueryResponse>> GetVlanById(Guid id)
        {
            var getVlanDetailQuery = new GetVlanDetailQuery()
            {
                Id = id
            };

            var response = await _mediator.Send(getVlanDetailQuery);

            return Ok(response);
        }
    }
}