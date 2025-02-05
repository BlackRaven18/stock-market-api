using dotnet_web_api.Models;

namespace dotnet_web_api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
