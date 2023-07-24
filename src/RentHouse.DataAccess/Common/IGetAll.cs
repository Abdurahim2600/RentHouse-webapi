using RentHouse.DataAccess.Utils;

namespace RentHouse.DataAccess.Common;

public interface IGetAll<TModel>
{
    public Task<IList<TModel>> GetAllAsync(PaginationParams @params);
}
