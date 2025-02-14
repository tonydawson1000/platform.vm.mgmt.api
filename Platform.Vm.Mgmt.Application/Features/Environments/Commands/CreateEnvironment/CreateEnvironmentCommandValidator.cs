using FluentValidation;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Application.Features.Environments.Commands.CreateEnvironment
{
    public class CreateEnvironmentCommandValidator : AbstractValidator<CreateEnvironmentCommand>
    {
        private readonly IEnvironmentRepository _environmentRepository;

        public CreateEnvironmentCommandValidator(IEnvironmentRepository environmentRepository)
        {
            _environmentRepository = environmentRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Tier)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .InclusiveBetween(1, 4).WithMessage("{PropertyName} must be between 1 and 4.");

            RuleFor(p => p.Sequence)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);


            RuleFor(e => e)
                .MustAsync(EnvironmentNameUnique)
                .WithMessage("An 'Environment' with that Name - '{p.Name}' - already exists.");

            RuleFor(e => e)
                .MustAsync(EnvironmentSequenceUnique)
                .WithMessage("An 'Environment' with that Sequence Number - '{p.Sequence}' - already exists.");
        }

        private async Task<bool> EnvironmentNameUnique(CreateEnvironmentCommand e, CancellationToken cancellationToken)
        {
            return !await _environmentRepository.IsEnvironmentNameUnique(e.Name);
        }

        private async Task<bool> EnvironmentSequenceUnique(CreateEnvironmentCommand e, CancellationToken cancellationToken)
        {
            return !await _environmentRepository.IsEnvironmentSequenceUnique(e.Sequence);
        }
    }
}