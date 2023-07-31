using RentHouse.DataAccess.Utils;
using RentHouse.Domain.Entities.Apartments;

namespace RentHouse.DataAccess.Interface.Searchs;

public interface ISearchRepository
{
    Task<IList<Apartment>> SearchAsync(Apartment commonPrice, Apartment roomCount, Apartment describtion);


    Task<IList<Apartment>> GetAllAsync(PaginationParams @params);
}
