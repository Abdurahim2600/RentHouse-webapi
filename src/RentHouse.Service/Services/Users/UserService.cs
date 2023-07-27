using RentHouse.DataAccess.Interface.Users;
using RentHouse.DataAccess.Utils;
using RentHouse.DataAccess.ViewModel;
using RentHouse.Domain.Entities.Users;
using RentHouse.Domain.Exeptions.Files;
using RentHouse.Domain.Exeptions.Users;
using RentHouse.Service.Dtos.Users;
using RentHouse.Service.Intesfaces.Commons;
using RentHouse.Service.Intesfaces.Users;

namespace RentHouse.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository repository;
    private readonly IFIleService _fileServise;
    public UserService(IUserRepository user,
        IFIleService fIleService)
    {
        this.repository = user;
        this._fileServise = fIleService;
    }
    public async Task<long> CountAsync() => await repository.CountAsync();


    public async Task<bool> CreateAsync(UserCreateDto dto)
    {
        string imagepaht = await _fileServise.UploadImageAsync(dto.ImagePath!);

        User user = new User()
        {

            FirstName = dto.FirstName,
            Email = dto.Email,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            PassportSeriaNumber = dto.Passport,
            IsMale = dto.IsMale,
            BirthDate = dto.BirthDate,
            Password = dto.Password,
            ImagePath = imagepaht,
            
            
        };
        var result = await repository.CreateAsync(user);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long userId)
    {
        var user = await repository.GetByIdAsync(userId);
        if (user is null) throw new UserNotFoundExeption();

        var result = await _fileServise.DeleteImageAsync(user.ImagePath);
        if (result == false) throw new ImageNotFoundExeptions();

        var dbResult = await repository.DeleteAsync(userId);
        return dbResult > 0;
    }

    public async Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params)
    {
        var user = await repository.GetAllAsync(@params);
        return user;
    }

    public async Task<UserViewModel> GetByIdAsync(long id)
    {
        var user = await repository.GetByIdAsync(id);
        if (user is null) throw new UserNotFoundExeption();
        else return user;
    }

  
}
