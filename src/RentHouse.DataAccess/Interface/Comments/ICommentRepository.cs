using RentHouse.DataAccess.Common;
using RentHouse.Domain.Entities.Apartments;

namespace RentHouse.DataAccess.Interface.Comments;

public interface ICommentRepository : IRepository<Apartment,Apartment>,
    IGetAll<Apartment>
{
}
