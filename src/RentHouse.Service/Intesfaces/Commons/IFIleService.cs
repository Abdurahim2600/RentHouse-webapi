using Microsoft.AspNetCore.Http;

namespace RentHouse.Service.Intesfaces.Commons;

public interface IFIleService
{
    //return sub path of this image
    public Task<string> UploadImageAsync(IFormFile image);


    public Task<bool> DeleteImageAsync(string subpath);

    //return sub path of this avatar
    public Task<string> UploadAvatarAsync(IFormFile avatar);


    public Task<bool> DeleteAvatarAsync(string subpath);

}
