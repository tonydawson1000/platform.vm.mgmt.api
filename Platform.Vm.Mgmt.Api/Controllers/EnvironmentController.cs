﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentDetail;
using Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentsList;

namespace Platform.Vm.Mgmt.Api.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class EnvironmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EnvironmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllEnvironments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetEnvironmentsListQueryResponse>> GetAllEnvironments()
        {
            var response = await _mediator.Send(new GetEnvironmentsListQuery());

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetEnvironmentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetEnvironmentDetailQueryResponse>> GetEnvironmentById(Guid id)
        {
            var getEnvironmentDetailQuery = new GetEnvironmentDetailQuery()
            {
                Id = id
            };

            var response = await _mediator.Send(getEnvironmentDetailQuery);

            return Ok(response);
        }
    }
}