using FluentValidation;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Commands.CreateDataCentre
{
    public class CreateDataCentreCommandValidator : AbstractValidator<CreateDataCentreCommand>
    {
        private readonly IDataCentreRepository _dataCentreRepository;

        public CreateDataCentreCommandValidator(IDataCentreRepository dataCentreRepository)
        {
            _dataCentreRepository = dataCentreRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Location)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");


            RuleFor(e => e)
                .MustAsync(DataCentreNameUnique)
                .WithMessage("A 'DataCentre' with that Name - '{p.Name}' - already exists.");
        }

        private async Task<bool> DataCentreNameUnique(CreateDataCentreCommand dc, CancellationToken cancellationToken)
        {
            return !await _dataCentreRepository.IsDataCentreNameUnique(dc.Name);
        }
    }
}