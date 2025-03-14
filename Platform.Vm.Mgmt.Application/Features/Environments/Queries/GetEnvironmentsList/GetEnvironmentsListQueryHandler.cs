﻿using AutoMapper;
using MediatR;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentsList
{
    public class GetEnvironmentsListQueryHandler
        : IRequestHandler<GetEnvironmentsListQuery, GetEnvironmentsListQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.Environment> _environmentRepository;

        public GetEnvironmentsListQueryHandler(
            IMapper mapper,
            IAsyncRepository<Domain.Entities.Environment> environmentRepository)
        {
            _mapper = mapper;
            _environmentRepository = environmentRepository;
        }

        public async Task<GetEnvironmentsListQueryResponse>
            Handle(GetEnvironmentsListQuery request, CancellationToken cancellationToken)
        {
            var getEnvironmentsListQueryResponse = new GetEnvironmentsListQueryResponse();

            var allEnvironments = (await _environmentRepository.ListAllAsync()).OrderBy(x => x.Sequence);

            var environmentListModels = _mapper.Map<List<EnvironmentListModel>>(allEnvironments);

            getEnvironmentsListQueryResponse.EnvironmentListModels = environmentListModels;

            return getEnvironmentsListQueryResponse;
        }
    }
}