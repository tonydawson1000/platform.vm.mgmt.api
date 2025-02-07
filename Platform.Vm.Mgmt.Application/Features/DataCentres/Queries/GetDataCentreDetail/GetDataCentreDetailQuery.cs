using MediatR;

namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentreDetail
{
    public class GetDataCentreDetailQuery : IRequest<DataCentreDetailModel>
    {
        public Guid Id { get; set; }
    }
}