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
    public class ComplicationService : IComplicationService
    {
        public IComplicationRepository _complicationRepository { get; set; }
        private readonly IMapper _mapper;
        public ComplicationService(IComplicationRepository complicationRepository, IMapper mapper)
        {
            _complicationRepository = complicationRepository;
            _mapper = mapper;
        }

        public int SaveComplication(ComplicationDto complicationDto)
        {
            return _complicationRepository.SaveComplication(complicationDto);
        }

        public async Task<List<ComplicationDto>> GetComplications(string? complicationName)
        {
            return await _complicationRepository.GetComplications(complicationName);
        }
    }
}
