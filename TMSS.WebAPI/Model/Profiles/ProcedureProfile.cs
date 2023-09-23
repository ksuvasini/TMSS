using AutoMapper;
using TMSS.DataAccess.Entities;
using TMSS.Domain.DTO;

namespace TMSS.WebAPI.Model.Profiles
{
    public class ProcedureProfile : Profile
    {
        public ProcedureProfile()
        {
            CreateMap<Procedure, ProcedureDto>();
            CreateMap<ProcedureDto, ProcedureViewModel>();
        }
    }
}
