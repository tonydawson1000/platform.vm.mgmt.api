using Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentsList;

namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresListWithEnvironments
{
    public class DataCentreWithEnvironmentsListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsEnabled { get; set; } = true;

        public string? Location { get; set; }

        public ICollection<EnvironmentListModel>? EnvironmentListModels { get; set; }
    }
}