using Dapper;
using RentHouse.DataAccess.Interface.Searchs;
using RentHouse.DataAccess.Utils;
using RentHouse.Domain.Entities.Apartments;

namespace RentHouse.DataAccess.Repository.Searchs;

public class SearchRepository : BaseRepository, ISearchRepository
{
    public async Task<IList<Apartment>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM apartment order by id desc " +
                $"offset {0} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<Apartment>(query)).ToList();
            return result;
        }
        catch
        {

            return new List<Apartment>();

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
    public Task<IList<Apartment>> SearchAsync(Apartment commonPrice, Apartment roomCount, Apartment describtion)
    {
        throw new NotImplementedException();
    }
}
