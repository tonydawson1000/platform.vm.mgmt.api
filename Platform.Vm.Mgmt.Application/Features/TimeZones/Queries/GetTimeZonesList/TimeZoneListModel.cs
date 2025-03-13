namespace Platform.Vm.Mgmt.Application.Features.TimeZones.Queries.GetTimeZonesList
{
    public class TimeZoneListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsEnabled { get; set; } = true;
        public int? Sequence { get; set; }

        public string Code { get; set; } = string.Empty;
    }
}