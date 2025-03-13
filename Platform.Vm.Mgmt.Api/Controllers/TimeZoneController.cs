using MediatR;
using Microsoft.AspNetCore.Mvc;
using Platform.Vm.Mgmt.Application.Features.TimeZones.Queries.GetTimeZonesList;

namespace Platform.Vm.Mgmt.Api.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class TimeZoneController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TimeZoneController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllTimeZones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetTimeZonesListQueryResponse>> GetAllTimeZones()
        {
            var response = await _mediator.Send(new GetTimeZonesListQuery());

            return Ok(response);
        }
    }
}