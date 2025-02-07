using Platform.Vm.Mgmt.Application.Responses;

namespace Platform.Vm.Mgmt.Application.Features.Vlans.Commands.CreateVlan
{
    public class CreateVlanCommandResponse : BaseResponse
    {
        public CreateVlanCommandResponse() : base() { }

        public CreateVlanModel CreateVlanModel { get; set; } = default!;
    }
}