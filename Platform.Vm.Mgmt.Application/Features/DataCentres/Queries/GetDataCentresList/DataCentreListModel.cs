﻿namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresList
{
    public class DataCentreListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsEnabled { get; set; } = true;

        public string? Location { get; set; }
    }
}