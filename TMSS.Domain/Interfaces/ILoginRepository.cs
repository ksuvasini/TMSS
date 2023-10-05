using TMSS.Domain.DTO;

namespace TMSS.Domain.Interfaces
{
    public interface ILoginRepository
    {
        UserDto IsAuthenticated(UserDto userDto);

        List<UserRoleDto> GetUserRoles(UserDto userDto);
    }
}
