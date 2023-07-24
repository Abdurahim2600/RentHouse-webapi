using RentHouse.DataAccess.Utils;
using RentHouse.Domain.Entities.Apartments;
using RentHouse.Service.Dtos.Apartments;

namespace RentHouse.Service.Intesfaces.Apartments;

public interface IApartmentService
{
    public Task<bool> CreateAsync(ApartmentCreatedDto dto);


    public Task<IList<Apartment>> GetAllAsync(PaginationParams @params);

    public Task<bool> DeleteAsync(long apartmentId);

    public Task<long> CountAsync();


    public Task<bool> UpdateAsync(long apartmentId,ApartmentUpdateDto dto);


    public Task<Apartment> GetByIdAsync(long id);


    
}
