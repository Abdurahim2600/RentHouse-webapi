﻿using RentHouse.DataAccess.Interface.Apartments;
using RentHouse.DataAccess.Utils;
using RentHouse.Domain.Entities.Apartments;
using RentHouse.Domain.Exeptions.Apartments;
using RentHouse.Domain.Exeptions.Files;
using RentHouse.Service.Commons.Healpers;
using RentHouse.Service.Dtos.Apartments;
using RentHouse.Service.Intesfaces.Apartments;
using RentHouse.Service.Intesfaces.Commons;
namespace RentHouse.Service.Services.Apartments;

public class ApartmentService : IApartmentService
{
    private readonly IApartmentRepository repository;
    private readonly IFIleService _fileServise;

    public ApartmentService(IApartmentRepository apartmentRepository,
        IFIleService fIleService)
    {
        this.repository = apartmentRepository;
        this._fileServise = fIleService;
    }
    public async Task<long> CountAsync() => await repository.CountAsync();


    public async Task<bool> CreateAsync(ApartmentCreatedDto dto)
    {
        string imagepaht = await _fileServise.UploadImageAsync(dto.ImagePath);

        Apartment apartment = new Apartment()
        {

            ImagePath = imagepaht,
            Description = dto.Describtion,
            CommonPrice = dto.CommonPrice,
            RoomCount = dto.RoomCount,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime(),
            Comment = dto.Comment
        };
        var result = await repository.CreateAsync(apartment);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long apartmentId)
    {
        var apartment = await repository.GetByIdAsync(apartmentId);
        if (apartment is null) throw new ApartmentNotFoundExeptions();

        var result = await _fileServise.DeleteImageAsync(apartment.ImagePath);
        if (result == false) throw new ImageNotFoundExeptions();

        var dbResult = await repository.DeleteAsync(apartmentId);
        return dbResult > 0;

    }
    public async Task<bool> UpdateAsync(long apartmentId, ApartmentCreatedDto dto)
    {

        var apartment = await repository.GetByIdAsync(apartmentId);
        if (apartment is null) throw new ApartmentNotFoundExeptions();

        // parse new items to category

        apartment.Description = dto.Describtion;
        apartment.CommonPrice = dto.CommonPrice;
        apartment.RoomCount = dto.RoomCount;
        apartment.Comment = dto.Comment;
        if (dto.ImagePath is not null)
        {
            // delete old image
            var deleteResult = await _fileServise.DeleteImageAsync(apartment.ImagePath);
            if (deleteResult is false) throw new ImageNotFoundExeptions();

            // upload new image
            string newImagePath = await _fileServise.UploadImageAsync(dto.ImagePath);

            // parse new path to category
            apartment.ImagePath = newImagePath;
        }
        //else category old image have to save

        apartment.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await repository.UpdateAsync(apartmentId, apartment);
        return dbResult > 0;
    }
    public async Task<IList<Apartment>> GetAllAsync(PaginationParams @params)
    {
        var apartments = await repository.GetAllAsync(@params);
        return apartments;
    }

    public async Task<Apartment> GetByIdAsync(long id)
    {
        var apartments = await repository.GetByIdAsync(id);
        if (apartments is null) throw new ApartmentNotFoundExeptions();
        else return apartments;
    }

    public async Task<bool> UpdateAsync(long apartmentId, ApartmentUpdateDto dto)
    {
        var apartment = await repository.GetByIdAsync(apartmentId);
        if (apartment is null) throw new ApartmentNotFoundExeptions();

        //parse new items to apartment
        apartment.Description = dto.Describtion;
        apartment.CommonPrice = dto.CommonPrice;
        apartment.RoomCount = dto.RoomCount;
        apartment.Comment = dto.Comment;



        if (dto.ImagePath is not null)
        {
            var deleteResult = await _fileServise.DeleteImageAsync(apartment.ImagePath);
            if (deleteResult is false) throw new ImageNotFoundExeptions();
            //upload new image
            apartment.ImagePath = await _fileServise.UploadImageAsync(dto.ImagePath);
        }
        //path new pars apartment
        apartment.UpdatedAt = TimeHelper.GetDateTime();
        var dbResult = await repository.UpdateAsync(apartmentId, apartment);
        return dbResult > 0;
        //else return false;
    }


}
