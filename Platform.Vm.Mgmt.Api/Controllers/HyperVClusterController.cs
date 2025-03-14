using MediatR;
using Microsoft.AspNetCore.Mvc;
using Platform.Vm.Mgmt.Application.Features.HyperVClusters.Queries.GetHyperVClusterDetail;
using Platform.Vm.Mgmt.Application.Features.HyperVClusters.Queries.GetHyperVClustersList;

namespace Platform.Vm.Mgmt.Api.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class HyperVClusterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HyperVClusterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllHyperVClusters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetHyperVClustersListQueryResponse>> GetAllHyperVClusters()
        {
            var response = await _mediator.Send(new GetHyperVClustersListQuery());

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetHyperVClusterById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetHyperVClusterDetailQueryResponse>> GetHyperVClusterById(Guid id)
        {
            var getHyperVClusterDetailQuery = new GetHyperVClusterDetailQuery()
            {
                Id = id
            };

            var response = await _mediator.Send(getHyperVClusterDetailQuery);

            return Ok(response);
        }
    }
}