using RentHouse.DataAccess.Utils;

namespace RentHouse.DataAccess.Common.Interface;

public interface ISearchable<TModel>
{
    public Task<(int itemsCount, IList<TModel>)> SearchAsync(string search,
        PaginationParams paginationParams);

}
