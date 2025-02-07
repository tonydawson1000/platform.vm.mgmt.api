using Platform.Vm.Mgmt.Application.Responses;

namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Commands.CreateDataCentre
{
    public class CreateDataCentreCommandResponse : BaseResponse
    {
        public CreateDataCentreCommandResponse() : base() { }

        public CreateDataCentreModel CreateDataCentreModel { get; set; } = default!;
    }
}