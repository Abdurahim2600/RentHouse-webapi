using RentHouse.DataAccess.Common;
using RentHouse.DataAccess.Common.Interface;
using RentHouse.Domain.Entities.Admins;

namespace RentHouse.DataAccess.Interface.Admins;

public interface IAdminRepository : IRepository<Admin, Admin>,
    IGetAll<Admin>
{
    
}
