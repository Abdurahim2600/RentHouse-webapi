using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RentHouse.Service.Commons.Healpers;
using RentHouse.Service.Intesfaces.Commons;

namespace RentHouse.Service.Services.Commons;

public class FileService : IFIleService
{
    public readonly string MEDIA = "media";
    public readonly string IMAGES = "images";
    public readonly string AVATARS = "avatar";
    public readonly string ROOTPATH;
    public FileService(IWebHostEnvironment env)
    {
        ROOTPATH = env.WebRootPath;
    }
    

    public async Task<bool> DeleteImageAsync(string subpath)
    {
        string path = Path.Combine(ROOTPATH,subpath);
        if (File.Exists(path))
        {
            await Task.Run(() =>
            {
                File.Delete(path);
            });
            return true;
        }
        else return false;
    }

    

    public async Task<string> UploadImageAsync(IFormFile image)
    {
        string newimageName = MediaHealper.MakeImageName(image.FileName);
        string subpath = Path.Combine(MEDIA, IMAGES,newimageName);
        string path = Path.Combine(ROOTPATH,subpath);
        var stream = new FileStream(path, FileMode.Create);
        await image.CopyToAsync(stream);
        stream.Close();

        return subpath;
    }

    Task<bool> IFIleService.DeleteAvatarAsync(string subpath)
    {
        throw new NotImplementedException();
    }

    Task<string> IFIleService.UploadAvatarAsync(IFormFile avatar)
    {
        throw new NotImplementedException();
    }
}
