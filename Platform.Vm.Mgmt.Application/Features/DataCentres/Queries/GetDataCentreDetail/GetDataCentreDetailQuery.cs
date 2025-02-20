using MediatR;

namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentreDetail
{
    public class GetDataCentreDetailQuery : IRequest<GetDataCentreDetailQueryResponse>
    {
        public Guid Id { get; set; }
    }
}