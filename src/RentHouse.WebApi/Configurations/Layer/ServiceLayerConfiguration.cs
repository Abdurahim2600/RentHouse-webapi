using Microsoft.AspNetCore.Cors.Infrastructure;
using RentHouse.Service.Intesfaces.Admins;
using RentHouse.Service.Intesfaces.Apartments;
using RentHouse.Service.Intesfaces.Auth;
using RentHouse.Service.Intesfaces.Commons;
using RentHouse.Service.Intesfaces.Notifications;
using RentHouse.Service.Intesfaces.Users;
using RentHouse.Service.Services.Admins;
using RentHouse.Service.Services.Apartments;
using RentHouse.Service.Services.Auth;
using RentHouse.Service.Services.Commons;
using RentHouse.Service.Services.Notifications;
using RentHouse.Service.Services.Users;

namespace RentHouse.WebApi.Configurations.Layer;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<IAdminService, AdminService>();
        builder.Services.AddScoped<IFIleService, FileService>();
        builder.Services.AddScoped<IApartmentService, ApartmentService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddSingleton<IEmailSender, SmsSender>();

    }
}
