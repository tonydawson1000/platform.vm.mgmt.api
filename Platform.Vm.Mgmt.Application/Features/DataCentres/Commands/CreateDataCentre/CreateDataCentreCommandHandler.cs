using AutoMapper;
using MediatR;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Commands.CreateDataCentre
{
    public class CreateDataCentreCommandHandler
        : IRequestHandler<CreateDataCentreCommand, CreateDataCentreCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDataCentreRepository _dataCentreRepository;

        public CreateDataCentreCommandHandler(
            IMapper mapper,
            IDataCentreRepository dataCentreRepository)
        {
            _mapper = mapper;
            _dataCentreRepository = dataCentreRepository;
        }

        public async Task<CreateDataCentreCommandResponse>
            Handle(CreateDataCentreCommand request, CancellationToken cancellationToken)
        {
            var createDataCentreCommandResponse = new CreateDataCentreCommandResponse();

            var validator = new CreateDataCentreCommandValidator(_dataCentreRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                createDataCentreCommandResponse.Success = false;
                createDataCentreCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createDataCentreCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createDataCentreCommandResponse.Success)
            {
                var dataCentre = new Domain.Entities.DataCentre()
                {
                    Name = request.Name,
                    Description = request.Description,
                    IsEnabled = request.IsEnabled,

                    Location = request.Location
                };

                dataCentre = await _dataCentreRepository.AddAsync(dataCentre);

                var createDataCentreModel = _mapper.Map<CreateDataCentreModel>(dataCentre);

                createDataCentreCommandResponse.CreateDataCentreModel = createDataCentreModel;
            }

            return createDataCentreCommandResponse;
        }
    }
}