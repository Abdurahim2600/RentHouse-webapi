using Dapper;
using Microsoft.AspNet.Identity;
using RentHouse.DataAccess.Interface.Admins;
using RentHouse.DataAccess.Utils;
using RentHouse.Domain.Entities.Admins;
using RentHouse.Domain.Entities.Apartments;

namespace RentHouse.DataAccess.Repository.admins;

public class AdminRepository : BaseRepository, IAdminRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from admins";
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


    public async Task<IList<Admin>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM admins order by id desc " +
                $"offset {0} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<Admin>(query)).ToList();
            return result;
        }
        catch
        {

            return new List<Admin>();

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
    public async Task<int> CreateAsync(Admin entity)
    {
        try
        {
          
            await _connection.OpenAsync();
            string query = "INSERT INTO public.admins(" +
                "first_name, last_name, phone_number, is_male, password, image_path, created_at, updated_at)" +
                "VALUES (@FirstName, @LastName, @PhoneNumber, @Ismale, @Password, @ImagePath, @CreatedAt, @UpdatedAt);";
            var result = await _connection.ExecuteAsync(query, entity);
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

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"DELETE FROM admins WHERE id=@Id";
            var result = await _connection.ExecuteAsync(query, new { Id = id });
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

    public async Task<Admin?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM admins where id = @Id";
            var result = await _connection.QuerySingleAsync<Admin>(query, new { Id = id });
            return result;
        }
        catch
        {

            return null;

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<int> UpdateAsync(long id, Admin entity)
    {
        throw new NotImplementedException();
    }

    

    public Task<IList<Apartment>> SearchAsync(Apartment describtion, Apartment commonPrice, Apartment roomCount)
    {
        throw new NotImplementedException();
    }

    public Task<int> CreateAsync(Admin entity, string PasswordHasher)
    {
        throw new NotImplementedException();
    }

    
}
