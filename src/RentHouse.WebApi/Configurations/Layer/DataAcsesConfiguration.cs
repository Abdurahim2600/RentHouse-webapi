using RentHouse.DataAccess.Interface.Admins;
using RentHouse.DataAccess.Interface.Apartments;
using RentHouse.DataAccess.Interface.Comments;
using RentHouse.DataAccess.Interface.Searchs;
using RentHouse.DataAccess.Interface.Users;
using RentHouse.DataAccess.Repository.admins;
using RentHouse.DataAccess.Repository.Apartments;
using RentHouse.DataAccess.Repository.Comments;
using RentHouse.DataAccess.Repository.Searchs;
using RentHouse.DataAccess.Repository.Users;

namespace RentHouse.WebApi.Configurations.Layer;

public static class DataAcsesConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<IApartmentRepository, ApartmentRepositorys>();
        builder.Services.AddScoped<IAdminRepository, AdminRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ICommentRepository, CommentRepository>();
        builder.Services.AddScoped<ISearchRepository, SearchRepository>();
        
    }
}
