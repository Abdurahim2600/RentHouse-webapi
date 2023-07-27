using RentHouse.DataAccess.Utils;
using RentHouse.Domain.Entities.Apartments;

namespace RentHouse.DataAccess.Common;

public interface IGetAll<TModel>
{
    public Task<IList<TModel>> GetAllAsync(PaginationParams @params);
    Task<IList<Apartment>> SearchAsync(Apartment describtion, Apartment commonPrice, Apartment roomCount);
}
