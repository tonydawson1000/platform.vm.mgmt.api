using Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentsList;

namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentreDetail
{
    public class DataCentreDetailModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public string? Location { get; set; }
        public bool? IsEnabled { get; set; }

        public ICollection<EnvironmentListModel>? EnvironmentListModels { get; set; }
    }
}