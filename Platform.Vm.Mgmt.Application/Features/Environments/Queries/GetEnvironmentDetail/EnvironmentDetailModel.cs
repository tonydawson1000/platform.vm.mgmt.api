using Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresList;
using Platform.Vm.Mgmt.Application.Features.Vlans.Queries.GetVlansList;

namespace Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentDetail
{
    public class EnvironmentDetailModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public int? Tier { get; set; }

        public int? Sequence { get; set; }

        public Guid DataCentreId { get; set; }
        public DataCentreListModel DataCentreListModel { get; set; } = default!;

        public ICollection<VlanListModel>? VlanListModels { get; set; }
    }
}