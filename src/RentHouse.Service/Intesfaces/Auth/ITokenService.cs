using RentHouse.Domain.Entities.Users;

namespace RentHouse.Service.Intesfaces.Auth;

public interface ITokenService
{
    public string GenerateToken(User user);
}
