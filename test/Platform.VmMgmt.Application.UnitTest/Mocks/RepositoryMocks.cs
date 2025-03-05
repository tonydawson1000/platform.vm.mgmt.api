using Moq;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.VmMgmt.Application.UnitTest.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IDataCentreRepository> GetDataCentreRepository()
        {
            var dataCentres = PopulateDummyDataCentreData();

            var mockDataCentreRepository = new Mock<IDataCentreRepository>();

            mockDataCentreRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(dataCentres);

            mockDataCentreRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid id) => dataCentres.FirstOrDefault(x => x.Id == id));

            mockDataCentreRepository.Setup(repo => repo.AddAsync(It.IsAny<Vm.Mgmt.Domain.Entities.DataCentre>()))
                .ReturnsAsync((Vm.Mgmt.Domain.Entities.DataCentre dataCentre) =>
                {
                    dataCentres.Add(dataCentre);
                    return dataCentre;
                });

            return mockDataCentreRepository;
        }

        private static List<Vm.Mgmt.Domain.Entities.DataCentre> PopulateDummyDataCentreData()
        {
            return new List<Vm.Mgmt.Domain.Entities.DataCentre>
            {
                new Vm.Mgmt.Domain.Entities.DataCentre
                {
                    Id = Guid.Parse("{B1A0D7A4-3D3D-4D3A-8D3D-3D3D3D3D3D3D}"),
                    Name = "DataCentre1",
                    Description = "DataCentre1 Description",
                    IsEnabled = true,
                    Location = "Location1",
                    Environments = new List<Vm.Mgmt.Domain.Entities.Environment>
                    {
                        new Vm.Mgmt.Domain.Entities.Environment
                        {
                            Id = Guid.Parse("{B1A0D7A4-3D3D-4D3A-8D3D-3D3D3D3D3D3D}"),
                            Name = "Environment1",
                            Description = "Environment1 Description",
                            IsEnabled = true,
                            DataCentreId = Guid.Parse("{B1A0D7A4-3D3D-4D3A-8D3D-3D3D3D3D3D3D}")
                        }
                    }
                },
                new Vm.Mgmt.Domain.Entities.DataCentre
                {
                    Id = Guid.Parse("{B1A0D7A4-3D3D-4D3A-8D3D-3D3D3D3D3D3D}"),
                    Name = "DataCentre2",
                    Description = "DataCentre2 Description",
                    IsEnabled = true,
                    Location = "Location2",
                    Environments = new List<Vm.Mgmt.Domain.Entities.Environment>
                    {
                        new Vm.Mgmt.Domain.Entities.Environment
                        {
                            Id = Guid.Parse("{B1A0D7A4-3D3D-4D3A-8D3D-3D3D3D3D3D3D}"),
                            Name = "Environment2",
                            Description = "Environment2 Description",
                            IsEnabled = true,
                            DataCentreId = Guid.Parse("{B1A0D7A4-3D3D-4D3A-8D3D-3D3D3D3D3D3D}")
                        }
                    }
                }
            };
        }

        public static Mock<IAsyncRepository<Vm.Mgmt.Domain.Entities.Environment>> GetEnvironmentRepository()
        {
            var environments = new List<Vm.Mgmt.Domain.Entities.Environment>
            {
                new Vm.Mgmt.Domain.Entities.Environment
                {
                    Id = Guid.Parse("{B1A0D7A4-3D3D-4D3A-8D3D-3D3D3D3D3D3D}"),
                    Name = "Environment1",
                    Description = "Environment1 Description",
                    IsEnabled = true,
                    DataCentreId = Guid.Parse("{B1A0D7A4-3D3D-4D3A-8D3D-3D3D3D3D3D3D}")
                },
                new Vm.Mgmt.Domain.Entities.Environment
                {
                    Id = Guid.Parse("{B1A0D7A4-3D3D-4D3A-8D3D-3D3D3D3D3D3D}"),
                    Name = "Environment2",
                    Description = "Environment2 Description",
                    IsEnabled = true,
                    DataCentreId = Guid.Parse("{B1A0D7A4-3D3D-4D3A-8D3D-3D3D3D3D3D3D}")
                }
            };

            var mockEnvironmentRepository = new Mock<IAsyncRepository<Vm.Mgmt.Domain.Entities.Environment>>();

            mockEnvironmentRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(environments);

            mockEnvironmentRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid id) => environments.FirstOrDefault(x => x.Id == id));

            return mockEnvironmentRepository;
        }

        public static Mock<IAsyncRepository<Vm.Mgmt.Domain.Entities.Vlan>> GetVlanRepository()
        {
            var vlans = new List<Vm.Mgmt.Domain.Entities.Vlan>
            {
                new Vm.Mgmt.Domain.Entities.Vlan
                {
                    Id = Guid.Parse("{B1A0D7A4-3D3D-4D3A-8D3D-3D3D3D3D3D3D}"),
                    Name = "Vlan1",
                    Description = "Vlan1 Description",
                    IsEnabled = true,
                    EnvironmentId = Guid.Parse("{B1A0D7A4-3D3D-4D3A-8D3D-3D3D3D3D3D3D}")
                },
                new Vm.Mgmt.Domain.Entities.Vlan
                {
                    Id = Guid.Parse("{B1A0D7A4-3D3D-4D3A-8D3D-3D3D3D3D3D3D}"),
                    Name = "Vlan2",
                    Description = "Vlan2 Description",
                    IsEnabled = true,
                    EnvironmentId = Guid.Parse("{B1A0D7A4-3D3D-4D3A-8D3D-3D3D3D3D3D3D}")
                }
            };

            var mockVlanRepository = new Mock<IAsyncRepository<Vm.Mgmt.Domain.Entities.Vlan>>();

            mockVlanRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(vlans);

            mockVlanRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid id) => vlans.FirstOrDefault(x => x.Id == id));

            return mockVlanRepository;
        }
    }
}