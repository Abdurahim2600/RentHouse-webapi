using Dapper;
using RentHouse.DataAccess.Interface;
using RentHouse.DataAccess.Interface.Users;
using RentHouse.DataAccess.Utils;
using RentHouse.DataAccess.ViewModel;
using RentHouse.Domain.Entities.Admins;
using RentHouse.Domain.Entities.Apartments;
using RentHouse.Domain.Entities.Users;

namespace RentHouse.DataAccess.Repository.Users;

public class UserRepository : BaseRepository, IUserRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from users";
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

    public async Task<int> CreateAsync(User entity)
    {
        try
        {

            await _connection.OpenAsync();
            string query = "INSERT INTO public.users(" +
                "first_name, last_name, phone_number, passport_seria_number, is_male, birth_date,identity_role, image_path, created_at, updated_at, email,password_hash,salt,emailconfirmed)" +
                "VALUES(@FirstName, @LastName, @PhoneNumber, @PassportSeriaNumber, @IsMale, @BirthDate, @IdentityRole, @ImagePath, @CreatedAt, @UpdatedAt,@Email,@PasswordHash,@Salt,@EmailConfirmed); ";
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
            string query = $"DELETE FROM users WHERE id=@Id";
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

    public async Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM users order by id desc " +
                $"offset {0} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<UserViewModel>(query)).ToList();
            return result;
        }
        catch
        {

            return new List<UserViewModel>();

        }
        finally
        {
            await _connection.CloseAsync();
        }
        
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT *FROM users WHERE email = @Email;";
            var data = await _connection.QuerySingleAsync<User>(query, new { Email = email });
            return data;
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

    public async Task<UserViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM users where id = @Id";
            var result = await _connection.QuerySingleAsync<UserViewModel>(query, new { Id = id });
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


    public async Task<User>GetByPhoneAsync(string phone)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM users where phone_number = @PhoneNumber";
            var data = await _connection.QuerySingleAsync<User>(query, new { PhoneNumber = phone });
            return data;
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
    public Task<IList<Apartment>> SearchAsync(Apartment describtion, Apartment commonPrice, Apartment roomCount)
    {
        throw new NotImplementedException();
    }

    public Task<(int itemsCount, IList<UserViewModel>)> SearchAsync(string search, PaginationParams paginationParams)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, User entity)
    {
        throw new NotImplementedException();
    }

    
}
