using RentHouse.DataAccess.Interface.Admins;
using RentHouse.DataAccess.Utils;
using RentHouse.Domain.Entities.Admins;
using RentHouse.Domain.Entities.Apartments;
using RentHouse.Domain.Exeptions.Admin;
using RentHouse.Domain.Exeptions.Apartments;
using RentHouse.Domain.Exeptions.Files;
using RentHouse.Service.Commons.Healpers;
using RentHouse.Service.Dtos.Admins;
using RentHouse.Service.Intesfaces.Admins;
using RentHouse.Service.Intesfaces.Commons;

namespace RentHouse.Service.Services.Admins;

public class AdminService : IAdminService
{
    private readonly IAdminRepository repository;
    private readonly IFIleService _fileServise;
    public AdminService(IAdminRepository admin,
        IFIleService fIleService)
    {
        this.repository = admin;
        this._fileServise = fIleService;
    }
    public async Task<long> CountAsync() => await repository.CountAsync();
    

    public async Task<bool> CreateAsync(AdminCreateDto dto)
    {
        string imagepaht = await _fileServise.UploadImageAsync(dto.ImagePath!);
        
        Admin admin = new Admin()
        {
            
            ImagePath = imagepaht,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            Ismale = dto.Ismale,
            
        };
        var result = await repository.CreateAsync(admin);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long adminId)
    {
        var admin = await repository.GetByIdAsync(adminId);
        if (admin is null) throw new AdminNotFoundExeption();

        var result = await _fileServise.DeleteImageAsync(admin.ImagePath);
        if (result == false) throw new ImageNotFoundExeptions();

        var dbResult = await repository.DeleteAsync(adminId);
        return dbResult > 0;
    }

    public async Task<IList<Admin>> GetAllAsync(PaginationParams @params)
    {
        var admin = await repository.GetAllAsync(@params);
        return admin;
    }

    public async Task<Admin> GetByIdAsync(long id)
    {
        var admin = await repository.GetByIdAsync(id);
        if (admin is null) throw new AdminNotFoundExeption();
        else return admin;
    }
}
