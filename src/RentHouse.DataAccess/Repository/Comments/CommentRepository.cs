using Dapper;
using RentHouse.DataAccess.Interface.Comments;
using RentHouse.DataAccess.Utils;
using RentHouse.Domain.Entities.Apartments;

namespace RentHouse.DataAccess.Repository.Comments;

public class CommentRepository : BaseRepository, ICommentRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from comment";
            var result = await _connection.QuerySingleAsync<long>(query);
            return result;
        }
        catch
        {

            return 0;

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<int> CreateAsync(Apartment entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Apartment>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<Apartment?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Apartment>> SearchAsync(Apartment describtion, Apartment commonPrice, Apartment roomCount)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Apartment entity)
    {
        throw new NotImplementedException();
    }
}
