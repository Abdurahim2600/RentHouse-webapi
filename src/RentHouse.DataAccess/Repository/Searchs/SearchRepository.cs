using Dapper;
using RentHouse.DataAccess.Interface;
using RentHouse.DataAccess.Interface.Searchs;
using RentHouse.DataAccess.Utils;
using RentHouse.Domain.Entities.Apartments;

namespace RentHouse.DataAccess.Repository.Searchs;

public class SearchRepository : BaseRepository, ISearchRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from apartment";
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

    public async Task<IList<Apartment>> SearchAsync(Apartment commonPrice, Apartment roomCount, Apartment describtion)
    {
       
            try
            {
                
                await _connection.OpenAsync();
                string query = $"SELECT * FROM apartment order by id desc " +
                    $"offset {0} limit {CountAsync()}";
                
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


    public Task<int> UpdateAsync(long id, Apartment entity)
    {
        throw new NotImplementedException();
    }

    
}
