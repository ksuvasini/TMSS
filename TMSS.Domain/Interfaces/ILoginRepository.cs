using TMSS.Domain.DTO;

namespace TMSS.Domain.Interfaces
{
    public interface ILoginRepository
    {
        List<UserDto> IsAuthenticated(UserDto userDto);
    }
}
