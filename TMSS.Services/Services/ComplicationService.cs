using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.Domain.Entities;
using TMSS.Domain.Interfaces;
using TMSS.Services.Interfaces;

namespace TMSS.Services.Services
{
    public class ComplicationService : IComplicationService
    {
        public IComplicationRepository _complicationRepository { get; set; }
        private readonly IMapper _mapper;
        public ComplicationService(IMapper mapper, IComplicationRepository complicationRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _complicationRepository = complicationRepository;
        }

        public async Task<IEnumerable<Complication>> GetComplications()
        {
            return _mapper.Map<List<Complication>>(await _complicationRepository.GetComplication());

        }
        public Complication CreateComplication(Complication complication)
        {
            return _mapper.Map<Complication>(_complicationRepository.CreateComplication(complication));
        }
        public Complication ModifyComplication(Complication complication)
        {
            return _mapper.Map<Complication>(_complicationRepository.ModifyComplication(complication));
        }

    }
}
