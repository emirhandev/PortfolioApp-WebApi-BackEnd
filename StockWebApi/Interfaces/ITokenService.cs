using StockWebApi.Models;

namespace StockWebApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);

    }
}
