using TMSS.Domain.DTO;

namespace TMSS.Services.Interfaces
{
    public interface ILoginService
    {
        UserDto IsAuthenticated(UserDto userDto);
    }
}
