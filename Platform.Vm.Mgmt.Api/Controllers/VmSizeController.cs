using MediatR;
using Microsoft.AspNetCore.Mvc;
using Platform.Vm.Mgmt.Application.Features.VmSizes.Queries;

namespace Platform.Vm.Mgmt.Api.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class VmSizeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VmSizeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllVmSizes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetVmSizesListQueryResponse>> GetAllVmSizes(bool includeDisabled)
        {
            var getVmSizesListQuery = new GetVmSizesListQuery()
            {
                IncludeDisabled = includeDisabled
            };

            var response = await _mediator.Send(getVmSizesListQuery);

            return Ok(response);
        }
    }
}