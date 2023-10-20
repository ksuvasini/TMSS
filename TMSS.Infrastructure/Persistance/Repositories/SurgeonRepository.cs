using AutoMapper;
using TMSS.DataAccess.DataContext;
using TMSS.Domain.DTO;
using TMSS.Domain.Entities;
using TMSS.Domain.Interfaces;
using TMSS.Web.Models;

namespace TMSS.Infrastructure.Persistance.Repositories
{
    public class SurgeonRepository : BaseRepository, ISurgeonRepository
    {
        public TMSSDbContext _tMSSDbContext { get; set; }
        private readonly IMapper _mapper;
        public SurgeonRepository(TMSSDbContext tMSSDbContext, IMapper mapper)
        {
            _tMSSDbContext = tMSSDbContext;
            _mapper = mapper;
        }

        public Task<SurgeonDto> SaveSurgeon(SurgeonDto surgeonDto)
        {
            Surgeon surgeon = _mapper.Map<Surgeon>(surgeonDto);
            if (surgeon.SurgeonId > 0)
            {
                var exisitingProcedure = _tMSSDbContext.Surgeon.FirstOrDefault(j => j.SurgeonId == surgeon.SurgeonId);
                exisitingProcedure.SurgeonName = surgeon.SurgeonName;
                //exisitingProcedure.
                exisitingProcedure.ModifiedBy = surgeon.ModifiedBy;
                exisitingProcedure.ModifiedDate = DateTime.Now;
            }
            else
            {
                surgeon.CreatedBy = "";
                surgeon.CreatedDate = DateTime.Now;
                _tMSSDbContext.Surgeon.Add(surgeon);
            }
            var result = _tMSSDbContext.SaveChanges();
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SurgeonDto>> GetSurgeons()
        {
            List<SurgeonDto> complications = new List<SurgeonDto>();
            complications.Add(new SurgeonDto() { SurgeonId = 1, SurgeonName = "Test", CreatedBy = "Admin", CreatedDate = DateTime.Now });
            // return await _tmssDbContext.Surgeon.ToListAsync();
            return (Task<IEnumerable<SurgeonDto>>)_mapper.Map<IEnumerable<SurgeonDto>>(complications);
        }
    }
}
