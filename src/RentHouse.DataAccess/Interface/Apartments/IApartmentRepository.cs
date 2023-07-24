using RentHouse.DataAccess.Common;
using RentHouse.DataAccess.Common.Interface;
using RentHouse.Domain.Entities.Apartments;

namespace RentHouse.DataAccess.Interface.Apartments;

public interface IApartmentRepository : IRepository<Apartment,Apartment>,
    IGetAll<Apartment>,ISearchable<Apartment>       
{
        

}
