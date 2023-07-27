using RentHouse.DataAccess.Utils;
using RentHouse.Domain.Entities.Admins;
using RentHouse.Domain.Entities.Apartments;
using RentHouse.Service.Dtos.Admins;
using RentHouse.Service.Dtos.Apartments;

namespace RentHouse.Service.Intesfaces.Admins;

public interface IAdminService
{
    public Task<bool> CreateAsync(AdminCreateDto dto);


    public Task<IList<Admin>> GetAllAsync(PaginationParams @params);

    public Task<bool> DeleteAsync(long adminId);

    public Task<long> CountAsync();

    public Task<Admin> GetByIdAsync(long id);

}
