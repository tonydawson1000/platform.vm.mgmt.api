using MediatR;

namespace Platform.Vm.Mgmt.Application.Features.VmOrders.Commands.CreateVmOrder
{
    public class CreateVmOrderCommand : IRequest<CreateVmOrderCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Guid EnvironmentId { get; set; }

        public Guid TimeZoneId { get; set; }

        public string PrimaryContactName { get; set; } = string.Empty;
        public string PrimaryContactEmail { get; set; } = string.Empty;
        public string TeamName { get; set; } = string.Empty;

        public ICollection<CreateVmOrderDetailModel>? VmOrderDetails { get; set; }
    }
}