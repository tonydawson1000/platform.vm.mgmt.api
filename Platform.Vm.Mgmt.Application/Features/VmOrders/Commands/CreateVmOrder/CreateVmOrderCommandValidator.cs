using FluentValidation;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Application.Features.VmOrders.Commands.CreateVmOrder
{
    public class CreateVmOrderCommandValidator : AbstractValidator<CreateVmOrderCommand>
    {
        public CreateVmOrderCommandValidator(IVmOrderRepository vmOrderRepository)
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.EnvironmentId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.TimeZoneId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.PrimaryContactName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.PrimaryContactEmail)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .EmailAddress().WithMessage("{PropertyName} must be a valid email address.");

            RuleFor(p => p.TeamName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}