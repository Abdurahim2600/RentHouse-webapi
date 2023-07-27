using RentHouse.DataAccess.Utils;
using RentHouse.DataAccess.ViewModel;
using RentHouse.Service.Dtos.Users;

namespace RentHouse.Service.Intesfaces.Users;

public interface IUserService
{
    public Task<bool> CreateAsync(UserCreateDto dto);


    public Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params);

    public Task<bool> DeleteAsync(long userId);

    public Task<long> CountAsync();

    public Task<UserViewModel> GetByIdAsync(long id);
}
