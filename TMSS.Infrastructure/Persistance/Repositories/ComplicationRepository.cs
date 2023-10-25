using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TMSS.DataAccess.DataContext;
using TMSS.Domain.DTO;
using TMSS.Domain.Entities;
using TMSS.Domain.Interfaces;

namespace TMSS.Infrastructure.Persistance.Repositories
{
    public class ComplicationRepository : IComplicationRepository
    {
        public TMSSDbContext _tMSSDbContext { get; set; }
        private readonly IMapper _mapper;
        public ComplicationRepository(TMSSDbContext tMSSDbContext, IMapper mapper)
        {
            _tMSSDbContext = tMSSDbContext;
            _mapper = mapper;
        }

        public int SaveComplication(ComplicationDto complicationDto)
        {
            //Complication complication = _mapper.Map<Complication>(complicationDto);
            if (complicationDto.ComplicationId > 0)
            {
                var exisitingComplication = _tMSSDbContext.Complication.FirstOrDefault(j => j.ComplicationId == complicationDto.ComplicationId);
                exisitingComplication.ComplicationName = complicationDto.ComplicationName;
                exisitingComplication.ModifiedBy = "Admin";
                exisitingComplication.ModifiedDate = DateTime.Now;
            }
            else
            {
                //complication.CreatedBy = complication.CreatedBy;
                //complication.CreatedDate = DateTime.Now;
                _tMSSDbContext.Complication.Add(new Complication
                {
                    ComplicationName = complicationDto.ComplicationName,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now
                });
            }
            return _tMSSDbContext.SaveChanges();
           // throw new NotImplementedException();
        }

        public async Task<List<ComplicationDto>> GetComplications(string? complicationName)
        {
            return _mapper.Map<List<ComplicationDto>>(_tMSSDbContext.Complication.ToList());
        }
    }
}
