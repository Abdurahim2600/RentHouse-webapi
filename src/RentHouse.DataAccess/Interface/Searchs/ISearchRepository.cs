using RentHouse.DataAccess.Common;
using RentHouse.Domain.Entities.Apartments;

namespace RentHouse.DataAccess.Interface.Searchs;

public interface ISearchRepository : IRepository<Apartment, Apartment>,
    IGetAll<Apartment>
{
    Task<IList<Apartment>>SearchAsync(Apartment commonPrice, Apartment roomCount,Apartment describtion);
    
}
