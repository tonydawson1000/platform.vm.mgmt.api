using MediatR;
using Microsoft.AspNetCore.Mvc;
using Platform.Vm.Mgmt.Application.Features.DataCentres.Commands.CreateDataCentre;
using Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentreDetail;
using Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresExport;
using Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresList;
using Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresListWithEnvironments;

namespace Platform.Vm.Mgmt.Api.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class DataCentreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DataCentreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllDataCentres")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetDataCentresListQueryResponse>> GetAllDataCentres()
        {
            var response = await _mediator.Send(new GetDataCentresListQuery());

            return Ok(response);
        }

        [HttpGet("allwithenvironments", Name = "GetDataCentresWithEnvironments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetDataCentresWithEnvironmentsListQueryResponse>> GetDataCentresWithEnvironments(bool includeDisabledEnvironments)
        {
            var getDataCentresWithEnvironmentsListQuery = new GetDataCentresWithEnvironmentsListQuery() 
            {
                IncludeDisabledEnvironments = includeDisabledEnvironments
            };

            var response = await _mediator.Send(getDataCentresWithEnvironmentsListQuery);
            
            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetDataCentreById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetDataCentreDetailQueryResponse>> GetDataCentreById(Guid id)
        {
            var getDataCentreDetailQuery = new GetDataCentreDetailQuery()
            {
                Id = id
            };

            var response = await _mediator.Send(getDataCentreDetailQuery);

            return Ok(response);
        }

        [HttpGet("export", Name = "ExportDataCentres")]
        public async Task<FileResult> ExportDataCentres()
        {
            var exportFileModel = await _mediator.Send(new GetDataCentresExportQuery());

            return File(exportFileModel.Data, exportFileModel.ContentType, exportFileModel.ExportFileName);
        }


        [HttpPost(Name = "AddDataCentre")]
        public async Task<ActionResult<CreateDataCentreCommandResponse>> Create([FromBody] CreateDataCentreCommand createDataCentreCommand)
        {
            var response = await _mediator.Send(createDataCentreCommand);

            return Ok(response);
        }
    }
}