using AutoMapper;
using System.Collections.Generic;
using TMSS.Domain.DTO;
using TMSS.Domain.Entities;
using TMSS.Domain.Interfaces;
using TMSS.Services.Interfaces;

namespace TMSS.Services.Services
{
    public class ProcedureService : IProcedureService
    {
        public IProcedureRepository _procedureRepository { get; set; }
        private readonly IMapper _mapper;
        public ProcedureService(IMapper mapper, IProcedureRepository procedureRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _procedureRepository = procedureRepository;
        }

        public async Task<IEnumerable<ProcedureDto>> GetProcedures(string? procedureName, string? clinicName)
        {
            //  var result = _procedureRepository.GetProcedures();
            return _mapper.Map<List<ProcedureDto>>(await _procedureRepository.GetProcedures(procedureName, clinicName));
            //   throw new NotImplementedException();
        }

        public ProcedureDto SaveProcedure(ProcedureDto procedureDto)
        {

            return _procedureRepository.SaveProcedure(procedureDto);
            throw new NotImplementedException();
        }
    }
}
