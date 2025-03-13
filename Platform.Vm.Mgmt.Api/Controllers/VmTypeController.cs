using MediatR;
using Microsoft.AspNetCore.Mvc;
using Platform.Vm.Mgmt.Application.Features.VmTypes.Queries.GetVmTypesList;

namespace Platform.Vm.Mgmt.Api.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class VmTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VmTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllVmTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetVmTypesListQueryResponse>> GetAllVmTypes(bool includeDisabled)
        {
            var getVmTypesListQuery = new GetVmTypesListQuery()
            {
                IncludeDisabled = includeDisabled
            };

            var response = await _mediator.Send(getVmTypesListQuery);

            return Ok(response);
        }
    }
}