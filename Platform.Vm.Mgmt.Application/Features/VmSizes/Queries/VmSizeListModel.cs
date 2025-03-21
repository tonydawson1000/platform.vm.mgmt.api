﻿namespace Platform.Vm.Mgmt.Application.Features.VmSizes.Queries
{
    public class VmSizeListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsEnabled { get; set; } = true;
        public int? Sequence { get; set; }

        public int? CpuCount { get; set; }
        public int? RamGb { get; set; }
        public int? HddGb { get; set; }
    }
}