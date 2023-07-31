using RentHouse.DataAccess.Utils;
using RentHouse.DataAccess.ViewModel;
using RentHouse.Domain.Entities.Apartments;

namespace RentHouse.Service.Intesfaces.Searchs;

public interface ISearchService
{
    public Task<IList<Apartment>> GetAllAsync(PaginationParams @params);
    public Task<IList<Apartment>> SearchAsync(Apartment describtion,Apartment commonPrice,Apartment roomCount);
}
