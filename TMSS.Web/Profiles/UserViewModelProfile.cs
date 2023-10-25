using AutoMapper;
using TMSS.Domain.DTO;
using TMSS.Domain.Entities;
using TMSS.Web.Models;

namespace TMSS.Web.Profiles
{
    public class UserViewModelProfile : Profile
    {
        public UserViewModelProfile()
        {
            CreateMap<Procedure, ProcedureDto>();
            CreateMap<ProcedureViewModel, ProcedureDto>();
            CreateMap<Clinic, ClinicDto>();
            CreateMap<ClinicViewModel, ClinicDto>();
            CreateMap<ClinicDto, ClinicViewModel>();
            CreateMap<ClinicDto, Clinic>();
            CreateMap<Clinic, ClinicDto>();
            CreateMap<User, UserDto>();
            CreateMap<UserRoleViewModel, UserRoleDto>();
            CreateMap<UserRoleDto, UserRoleViewModel>();
            CreateMap<UserDto, LoginViewModel>();
            CreateMap<LoginViewModel, UserDto>();
            CreateMap<RoleViewModel, RoleDto>();
            CreateMap<ComplicationViewModel, ComplicationDto>();
            CreateMap<ComplicationDto, ComplicationViewModel>();
            CreateMap<ComplicationDto, Complication>();
            CreateMap<Complication, ComplicationDto>();
            CreateMap<SurgeonViewModel, SurgeonDto>();
            CreateMap<SurgeonDto, Surgeon>();



        }

    }
}
