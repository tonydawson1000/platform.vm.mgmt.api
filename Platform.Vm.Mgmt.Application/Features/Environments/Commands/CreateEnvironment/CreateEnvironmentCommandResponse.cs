using Platform.Vm.Mgmt.Application.Responses;

namespace Platform.Vm.Mgmt.Application.Features.Environments.Commands.CreateEnvironment
{
    public class CreateEnvironmentCommandResponse : BaseResponse
    {
        public CreateEnvironmentCommandResponse() : base() { }

        public CreateEnvironmentModel CreateEnvironmentModel { get; set; } = default!;
    }
}