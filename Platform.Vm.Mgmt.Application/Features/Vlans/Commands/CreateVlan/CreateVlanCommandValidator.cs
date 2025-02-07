using FluentValidation;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Application.Features.Vlans.Commands.CreateVlan
{
    public class CreateVlanCommandValidator : AbstractValidator<CreateVlanCommand>
    {
        private readonly IVlanRepository _vlanRepository;

        public CreateVlanCommandValidator(IVlanRepository vlanRepository)
        {
            _vlanRepository = vlanRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");


            RuleFor(e => e)
                .MustAsync(VlanNameUnique)
                .WithMessage("A 'VLAN' with that Name - '{p.Name}' - already exists.");
        }

        private async Task<bool> VlanNameUnique(CreateVlanCommand v, CancellationToken cancellationToken)
        {
            return !await _vlanRepository.IsVlanNameUnique(v.Name);
        }
    }
}