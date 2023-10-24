using AutoMapper;
using TMSS.DataAccess.DataContext;
using TMSS.Domain.DTO;
using TMSS.Domain.Entities;
using TMSS.Domain.Interfaces;

namespace TMSS.Infrastructure.Persistance.Repositories
{
    public class ComplicationRepository : BaseRepository, IComplicationRepository
    {
        public TMSSDbContext _tMSSDbContext { get; set; }
        private readonly IMapper _mapper;
        public ComplicationRepository(TMSSDbContext tMSSDbContext, IMapper mapper)
        {
            _tMSSDbContext = tMSSDbContext;
            _mapper = mapper;
        }

        public ComplicationDto SaveProcedure(ComplicationDto complicationDto)
        {
            //Complication complication = _mapper.Map<Complication>(complicationDto);
            if (complicationDto.ComplicationId > 0)
            {
                var exisitingComplication = _tMSSDbContext.Complication.FirstOrDefault(j => j.ComplicationId == complicationDto.ComplicationId);
                exisitingComplication.ComplicationName = complicationDto.ComplicationName;
                exisitingComplication.ModifiedBy = complicationDto.ModifiedBy;
                exisitingComplication.ModifiedDate = DateTime.Now;
            }
            else
            {
                //complication.CreatedBy = complication.CreatedBy;
                //complication.CreatedDate = DateTime.Now;
                _tMSSDbContext.Complication.Add(new Complication
                {
                    ComplicationName = complicationDto.ComplicationName,
                    CreatedBy = complicationDto.CreatedBy,
                    CreatedDate = DateTime.Now
                });
            }
            var result = _tMSSDbContext.SaveChanges();
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ComplicationDto>> GetComplications()
        {
            List<ComplicationDto> complications = new List<ComplicationDto>();
            complications.Add(new ComplicationDto() { ComplicationId = 1, ComplicationName = "Test", CreatedBy = "Admin", CreatedDate = DateTime.Now });
            // return await _tmssDbContext.Procedure.ToListAsync();
            return (Task<IEnumerable<ComplicationDto>>)_mapper.Map<IEnumerable<ComplicationDto>>(complications);
        }
    }
}
