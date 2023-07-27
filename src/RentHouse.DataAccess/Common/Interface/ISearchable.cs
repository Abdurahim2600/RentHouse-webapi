using RentHouse.DataAccess.Utils;
using RentHouse.Domain.Entities.Users;

namespace RentHouse.DataAccess.Common.Interface;

public interface ISearchable<TModel>
{
    Task<User> GetByPhoneAsync(string phone);
    public Task<(int itemsCount, IList<TModel>)> SearchAsync(string search,
        PaginationParams paginationParams);

}
