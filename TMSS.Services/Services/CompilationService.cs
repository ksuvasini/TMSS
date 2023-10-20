using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.DataAccess.DataContext;
using TMSS.Domain.DTO;
using TMSS.Domain.Interfaces;
using TMSS.Services.Interfaces;

namespace TMSS.Services.Services
{
    public class CompilationService : ICompilationService
    {
        public IComplicationRepository _complicationRepository { get; set; }
        private readonly IMapper _mapper;
        public CompilationService(IComplicationRepository complicationRepository, IMapper mapper)
        {
            _complicationRepository = complicationRepository;
            _mapper = mapper;
        }

        public ComplicationDto SaveComplication(ComplicationDto complicationDto)
        {
            return _complicationRepository.SaveProcedure(complicationDto);
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ComplicationDto>> GetComplications()
        {
            return _complicationRepository.GetComplications();
            throw new NotImplementedException();
        }
    }
}
