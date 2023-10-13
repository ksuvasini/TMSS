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

        public async Task<IEnumerable<ProceduresClinic>> GetProcedures()
        {
            //  var result = _procedureRepository.GetProcedures();
            return _mapper.Map<List<ProceduresClinic>>(await _procedureRepository.GetProcedures());

            //   throw new NotImplementedException();
        }
        public ProceduresClinic CreateProcedure(ProceduresClinic procedure)
        {
            return _mapper.Map<ProceduresClinic>(_procedureRepository.CreateProcedure(procedure));
        }
        public ProceduresClinic ModifyProcedure(ProceduresClinic procedureclinic)
        {
            return _mapper.Map<ProceduresClinic>(_procedureRepository.ModifyProcedures(procedureclinic));
        }
    }
}
