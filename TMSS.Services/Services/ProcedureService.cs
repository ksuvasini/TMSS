using AutoMapper;
using System.Collections.Generic;
using TMSS.Domain.DTO;
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

        public async Task<IEnumerable<ProcedureDto>> GetProcedures()
        {
            //  var result = _procedureRepository.GetProcedures();
            return _mapper.Map<List<ProcedureDto>>(await _procedureRepository.GetProcedures());

            //   throw new NotImplementedException();
        }
    }
}
