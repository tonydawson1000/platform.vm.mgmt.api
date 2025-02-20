using AutoMapper;
using MediatR;
using Platform.Vm.Mgmt.Application.Contracts.Infrastructure.Export;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Queries.GetDataCentresExport
{
    public class GetDataCentresExportQueryHandler
        : IRequestHandler<GetDataCentresExportQuery, DataCentreExportFileModel>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.DataCentre> _dataCentreRepository;
        private readonly ICsvFileExporter _csvFileExport;

        public GetDataCentresExportQueryHandler(
            IMapper mapper,
            IAsyncRepository<Domain.Entities.DataCentre> dataCentreRepository,
            ICsvFileExporter csvFileExport)
        {
            _mapper = mapper;
            _dataCentreRepository = dataCentreRepository;
            _csvFileExport = csvFileExport;
        }

        public async Task<DataCentreExportFileModel> Handle(GetDataCentresExportQuery request, CancellationToken cancellationToken)
        {
            var allDataCentres = (await _dataCentreRepository.ListAllAsync()).OrderBy(x => x.Name);

            var allDataCentreModels = _mapper.Map<List<DataCentreExportModel>>(allDataCentres);

            var fileData = _csvFileExport.ExportDataCentresToCsv(allDataCentreModels);

            var dataCentreExportFileModel = new DataCentreExportFileModel()
            {
                ContentType = "text/csv",
                Data = fileData,
                ExportFileName = $"datacentre-export-{DateTime.Now.ToShortDateString().Replace("/", "-")}-{DateTime.Now.ToShortTimeString().Replace(":", "-")}.csv"
            };

            return dataCentreExportFileModel;
        }
    }
}