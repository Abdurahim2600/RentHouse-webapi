using RentHouse.DataAccess.Interface.Searchs;
using RentHouse.DataAccess.Utils;
using RentHouse.DataAccess.ViewModel;
using RentHouse.Domain.Entities.Apartments;
using RentHouse.Service.Intesfaces.Searchs;

namespace RentHouse.Service.Services.Searchs;

public class SearchService : ISearchService
{
    private readonly ISearchRepository _repository;

    public SearchService(ISearchRepository repository)
    {
        this._repository = repository;
    }

    Task<IList<Apartment>> ISearchService.GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    Task<IList<Apartment>> ISearchService.SearchAsync(Apartment describtion, Apartment commonPrice, Apartment roomCount)
    {
        throw new NotImplementedException();
    }
}
