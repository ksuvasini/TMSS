using TMSS.Domain.DTO;

namespace TMSS.Services.Interfaces
{
    public interface ILoginService
    {
        List<UserDto> IsAuthenticated(UserDto userDto);
    }
}
