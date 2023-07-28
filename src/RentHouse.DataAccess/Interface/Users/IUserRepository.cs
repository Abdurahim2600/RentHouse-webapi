using RentHouse.DataAccess.Common;
using RentHouse.DataAccess.Common.Interface;
using RentHouse.DataAccess.Utils;
using RentHouse.DataAccess.ViewModel;
using RentHouse.Domain.Entities.Users;

namespace RentHouse.DataAccess.Interface.Users;

public interface IUserRepository : IRepository<User, UserViewModel>,
    IGetAll<UserViewModel>
    
{
    public Task<User?> GetByEmailAsync(string email);
    public Task<User?> GetByPhoneAsync(string phone);
}
