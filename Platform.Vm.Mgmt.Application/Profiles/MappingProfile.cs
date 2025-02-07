using AutoMapper;
using Platform.Vm.Mgmt.Application.Features.DataCentres.Commands.CreateDataCentre;
using Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentreDetail;
using Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresList;
using Platform.Vm.Mgmt.Application.Features.Environments.Commands.CreateEnvironment;
using Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentDetail;
using Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentsList;
using Platform.Vm.Mgmt.Application.Features.Vlans.Commands.CreateVlan;
using Platform.Vm.Mgmt.Application.Features.Vlans.Queries.GetVlanDetail;
using Platform.Vm.Mgmt.Application.Features.Vlans.Queries.GetVlansList;


namespace Platform.Vm.Mgmt.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.DataCentre, DataCentreListModel>().ReverseMap();
            CreateMap<Domain.Entities.DataCentre, DataCentreDetailModel>().ReverseMap();
            CreateMap<Domain.Entities.DataCentre, CreateDataCentreCommand>().ReverseMap();
            CreateMap<Domain.Entities.DataCentre, CreateDataCentreModel>().ReverseMap();

            CreateMap<Domain.Entities.Environment, EnvironmentListModel>().ReverseMap();
            CreateMap<Domain.Entities.Environment, EnvironmentDetailModel>().ReverseMap();
            CreateMap<Domain.Entities.Environment, CreateEnvironmentCommand>().ReverseMap();
            CreateMap<Domain.Entities.Environment, CreateEnvironmentModel>().ReverseMap();

            CreateMap<Domain.Entities.Vlan, VlanListModel>().ReverseMap();
            CreateMap<Domain.Entities.Vlan, VlanDetailModel>().ReverseMap();
            CreateMap<Domain.Entities.Vlan, CreateVlanCommand>().ReverseMap();
            CreateMap<Domain.Entities.Vlan, CreateVlanModel>().ReverseMap();
        }
    }
}