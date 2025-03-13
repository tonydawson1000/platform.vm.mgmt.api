using AutoMapper;
using Platform.Vm.Mgmt.Application.Features.DataCentres.Commands.CreateDataCentre;
using Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentreDetail;
using Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresExport;
using Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresList;
using Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresListWithEnvironments;
using Platform.Vm.Mgmt.Application.Features.Environments.Commands.CreateEnvironment;
using Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentDetail;
using Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentsList;
using Platform.Vm.Mgmt.Application.Features.TimeZones.Queries.GetTimeZonesList;
using Platform.Vm.Mgmt.Application.Features.Vlans.Commands.CreateVlan;
using Platform.Vm.Mgmt.Application.Features.Vlans.Queries.GetVlanDetail;
using Platform.Vm.Mgmt.Application.Features.Vlans.Queries.GetVlansList;
using Platform.Vm.Mgmt.Application.Features.VmOrders.Commands.CreateVmOrder;
using Platform.Vm.Mgmt.Application.Features.VmOrders.Queries.GetVmOrderDetail;
using Platform.Vm.Mgmt.Application.Features.VmOrders.Queries.GetVmOrdersList;
using Platform.Vm.Mgmt.Application.Features.VmSizes.Queries;
using Platform.Vm.Mgmt.Application.Features.VmTypes.Queries.GetVmTypesList;


namespace Platform.Vm.Mgmt.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.VmOrder, VmOrderListModel>()
                .ForMember(dest => dest.VmOrderDetailListModels, opt => opt.MapFrom(src => src.VmOrderDetails));
            CreateMap<Domain.Entities.VmOrder, VmOrderDetailModel>()
                .ForMember(dest => dest.VmOrderDetailListModels, opt => opt.MapFrom(src => src.VmOrderDetails));

            CreateMap<Domain.Entities.VmOrder, CreateVmOrderCommand>().ReverseMap();
            CreateMap<Domain.Entities.VmOrder, CreateVmOrderModel>()
                .ForMember(dest => dest.VmOrderDetails, opt => opt.MapFrom(src => src.VmOrderDetails));

            CreateMap<Domain.Entities.VmOrderDetail, VmOrderDetailListModel>().ReverseMap();
            CreateMap<Domain.Entities.VmOrderDetail, CreateVmOrderDetailModel>().ReverseMap();

            //VmSize
            CreateMap<Domain.Entities.VmSize, VmSizeListModel>().ReverseMap();

            //VmType
            CreateMap<Domain.Entities.VmType, VmTypeListModel>().ReverseMap();

            //TimeZone
            CreateMap<Domain.Entities.TimeZone, TimeZoneListModel>().ReverseMap();

            CreateMap<Domain.Entities.Vlan, VlanListModel>().ReverseMap();
            CreateMap<Domain.Entities.Vlan, VlanDetailModel>().ReverseMap();
            CreateMap<Domain.Entities.Vlan, CreateVlanCommand>().ReverseMap();
            CreateMap<Domain.Entities.Vlan, CreateVlanModel>().ReverseMap();


            CreateMap<Domain.Entities.Environment, EnvironmentListModel>().ReverseMap();
            CreateMap<Domain.Entities.Environment, EnvironmentDetailModel>().ReverseMap();
            CreateMap<Domain.Entities.Environment, CreateEnvironmentCommand>().ReverseMap();
            CreateMap<Domain.Entities.Environment, CreateEnvironmentModel>().ReverseMap();


            CreateMap<Domain.Entities.DataCentre, DataCentreListModel>().ReverseMap();
            CreateMap<Domain.Entities.DataCentre, DataCentreWithEnvironmentsListModel>()
                .ForMember(dest => dest.EnvironmentListModels, opt => opt.MapFrom(src => src.Environments));

            CreateMap<Domain.Entities.DataCentre, DataCentreDetailModel>().ReverseMap();
            CreateMap<Domain.Entities.DataCentre, CreateDataCentreCommand>().ReverseMap();
            CreateMap<Domain.Entities.DataCentre, CreateDataCentreModel>().ReverseMap();

            CreateMap<Domain.Entities.DataCentre, DataCentreExportModel>();
        }
    }
}